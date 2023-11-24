using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Updates;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Updates
{
    public class AddUpdatesModel : PageModel
    {
		private readonly IUpdatesData updateDb;
        private readonly IAzureStorage storage;
        private readonly IHelperData helperDb;

        [BindProperty (SupportsGet = true)]
        public MyUpdateModel Update { get; set; }

        public IFormFile DescUpload { get; set; }
        public IFormFile CommChallengeUpload { get; set; }
        public IFormFile ImpactUpload { get; set; }

        public AddUpdatesModel(IUpdatesData updateDb, IAzureStorage storage, IHelperData helperDb)
        {
			this.updateDb = updateDb;
            this.storage = storage;
            this.helperDb = helperDb;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string descFileName = "Updates/" + helperDb.RandomNumber(1, 1000) + DescUpload.FileName;
            MyBlobResponseModel descResponse = await storage.UploadAsync(DescUpload, descFileName);

            string commChallengeFileName = "Updates/" + helperDb.RandomNumber(1, 1000) + DescUpload.FileName;
            MyBlobResponseModel challengeResponse = await storage.UploadAsync(DescUpload, commChallengeFileName);

            string impactFileName = "Updates/" + helperDb.RandomNumber(1, 1000) + DescUpload.FileName;
            MyBlobResponseModel impactResponse = await storage.UploadAsync(DescUpload, impactFileName);

            Update.DescriptionImage = descResponse.Blob.Uri;
            Update.ChallengeImage = challengeResponse.Blob.Uri;
            Update.ImpactImage = impactResponse.Blob.Uri;
            Update.AddedBy = "Admin";
            Update.DateAdded = DateTime.Now;

            updateDb.AddUpdate(Update);

            return RedirectToPage("AllUpdates");
        }
    }
}
