using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.News
{
    public class AddNewsModel : PageModel
    {
        private readonly INewsData newsDb;
        private readonly IAzureStorage storage;
        private readonly IHelperData helpDb;

        [BindProperty ( SupportsGet = true)]
        public MyNewsModel News { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty( SupportsGet = true)]
        public bool ImageIsSmall { get; set; }

        public AddNewsModel(INewsData newsDb, IAzureStorage storage, IHelperData helpDb)
        {
            this.newsDb = newsDb;
            this.storage = storage;
            this.helpDb = helpDb;
        }
        public void OnGet()
        {
            News.PublishDate = DateTime.Now;
            News.ExpiryDate = DateTime.Now;
        }

        public async Task<IActionResult> OnPost()
        {
            if (helpDb.IsImageSizeValid(Upload, 1894, 731))
            {
                string fileName = "News/" + helpDb.RandomNumber(0, 1000) + Upload.FileName;
                MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);

                News.DateCreated = DateTime.Now;
                News.CreatedBy = "Admin";
                News.ImageUrl = response.Blob.Uri;

                newsDb.AddNews(News);

                return RedirectToPage("AllNews");
            }

            ImageIsSmall = true;

            return Page();
           
        }

       
    }
}
