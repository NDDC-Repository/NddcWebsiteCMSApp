using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Publications;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Publications
{
    public class AddPublicationsModel : PageModel
    {
        private readonly IPublicationsData pubDb;
        private readonly IAzureStorage storage;

        [BindProperty]
        public MyPublicationModel Publication { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public AddPublicationsModel(IPublicationsData pubDb, IAzureStorage storage)
        {
            this.pubDb = pubDb;
            this.storage = storage;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            string fileName = "Photos/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
            MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
            Publication.PubThumbImage = response.Blob.Uri;
            Publication.DateUploaded = DateTime.Now;
            Publication.UploadedBy = "Admin";

            pubDb.AddPublication(Publication);
            return RedirectToPage("AllPublications");
        }
    }
}
