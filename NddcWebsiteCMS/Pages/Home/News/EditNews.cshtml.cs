using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.News
{
    public class EditNewsModel : PageModel
    {
        private readonly IConfiguration configuration;

        private readonly INewsData newsDb;
        [BindProperty(SupportsGet = true)]
        public MyNewsModel News { get; set; }

        public IFormFile Upload { get; set; }
        public EditNewsModel(IConfiguration configuration, INewsData newsDb)
        {
            this.configuration = configuration;
            this.newsDb = newsDb;
        }
        public void OnGet(int? nid)
        {
            News = newsDb.GetNewsDetails(nid.Value);
        }
    }
}
