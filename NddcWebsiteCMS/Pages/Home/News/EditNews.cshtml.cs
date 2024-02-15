using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.News
{
    public class EditNewsModel : PageModel
    {
        private readonly IConfiguration configuration;

        private readonly INewsData newsDb;
        private readonly IAzureStorage storage;
        private readonly IHelperData helpDb;

        [BindProperty(SupportsGet = true)]
        public MyNewsModel News { get; set; }

        public IFormFile Upload { get; set; }
        public EditNewsModel(IConfiguration configuration, INewsData newsDb, IAzureStorage storage, IHelperData helpDb)
        {
            this.configuration = configuration;
            this.newsDb = newsDb;
            this.storage = storage;
            this.helpDb = helpDb;
        }
        public void OnGet(int? nid)
        {
            News = newsDb.GetNewsDetails(nid.Value);
        }
        public async Task<IActionResult> OnPost(int? nid)
        {
            if (Upload is not null)
            {
                string fileName = "News/" + helpDb.RandomNumber(0, 1000) + Upload.FileName;
                MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
                News.ImageUrl = response.Blob.Uri;
            }
            News.NID = nid.Value;
            newsDb.UpdateNews(News);

            return RedirectToPage("AllNews");
        }
        public IActionResult OnPostDelete(int? nid)
        {
            //string fileName = "News/skill2.jpg";

            //MyBlobResponseModel response = await storage.DeleteAsync(fileName);

            newsDb.DeleteNews(nid.Value);

            //string containerName = "https://nddc-website.s3.eu-north-1.amazonaws.com/";
           

            return RedirectToPage("AllNews");
        }
    }
}
