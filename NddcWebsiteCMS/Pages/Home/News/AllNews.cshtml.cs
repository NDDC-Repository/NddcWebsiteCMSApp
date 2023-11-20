using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.News
{
    public class AllNewsModel : PageModel
    {
        private readonly INewsData newsDb;
        public readonly string _containerUrl;
        public List<MyNewsModel> NewsList { get; set; }

        public AllNewsModel(INewsData newsDb, IConfiguration configuration)
        {
            this.newsDb = newsDb;
            _containerUrl = configuration.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            
            NewsList = newsDb.AllNews();
            
        }
    }
}
