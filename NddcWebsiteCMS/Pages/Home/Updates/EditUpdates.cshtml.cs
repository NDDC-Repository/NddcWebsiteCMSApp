using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Updates;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Updates
{
    public class EditUpdatesModel : PageModel
    {
		private readonly IUpdatesData updateDb;
        private readonly IHelperData helperDb;
        private readonly IAzureStorage storage;

        [BindProperty]
        public MyUpdateModel Update { get; set; }
        public IFormFile DescUpload { get; set; }
        public IFormFile CommChallengeUpload { get; set; }
        public IFormFile ImpactUpload { get; set; }

        public EditUpdatesModel(IUpdatesData updateDb, IHelperData helperDb, IAzureStorage storage)
        {
			this.updateDb = updateDb;
            this.helperDb = helperDb;
            this.storage = storage;
        }
        public void OnGet(int? Id)
        {
            Update = updateDb.UpdatesDetails(Id.Value);

		}
		public async Task<IActionResult> OnPost()
		{
			

            if (DescUpload is not null)
            {
                string fileName = "Updates/" + helperDb.RandomNumber(1, 1000) + DescUpload.FileName;
                MyBlobResponseModel response = await storage.UploadAsync(DescUpload, fileName);
                Update.DescriptionImage = response.Blob.Uri;
            }
            if (CommChallengeUpload is not null)
            {
                string fileName = "Updates/" + helperDb.RandomNumber(1, 1000) + CommChallengeUpload.FileName;
                MyBlobResponseModel response = await storage.UploadAsync(CommChallengeUpload, fileName);
                Update.ChallengeImage = response.Blob.Uri;
            }
            if (ImpactUpload is not null)
            {
                string fileName = "Updates/" + helperDb.RandomNumber(1, 1000) + ImpactUpload.FileName;
                MyBlobResponseModel response = await storage.UploadAsync(ImpactUpload, fileName);
                Update.ImpactImage = response.Blob.Uri;
            }

            
            updateDb.EditUpdate(Update);

			return RedirectToPage("AllUpdates");
		}
	}
}
