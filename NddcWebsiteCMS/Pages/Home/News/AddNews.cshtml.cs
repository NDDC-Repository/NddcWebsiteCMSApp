using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.News
{
    public class AddNewsModel : PageModel
    {
        private readonly INewsData newsDb;
        private readonly IAzureStorage storage;

        [BindProperty ( SupportsGet = true)]
        public MyNewsModel News { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }

        public AddNewsModel(INewsData newsDb, IAzureStorage storage)
        {
            this.newsDb = newsDb;
            this.storage = storage;
        }
        public void OnGet()
        {
            News.PublishDate = DateTime.Now;
            News.ExpiryDate = DateTime.Now;
        }

        public async Task<IActionResult> OnPost()
        {
            MyBlobResponseModel? response = await storage.UploadAsync(Upload);


            News.DateCreated = DateTime.Now;
            News.CreatedBy = "Admin";
            News.ImageUrl = response.Blob.Uri;

            newsDb.AddNews(News);
            return RedirectToPage("AllNews");
        }
    }
}
