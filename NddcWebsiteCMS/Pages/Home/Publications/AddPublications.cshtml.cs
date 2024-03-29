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

        [BindProperty(SupportsGet = true)]
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
            string fileName = "Publications/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
            MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
            Publication.PubUploadUrl = response.Blob.Uri;

            pubDb.AddPublication(Publication);
            return RedirectToPage("AllPublications");
        }
    }
}
