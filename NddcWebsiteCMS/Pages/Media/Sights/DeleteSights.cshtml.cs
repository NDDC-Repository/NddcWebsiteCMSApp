using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class DeleteSightsModel : PageModel
    {
        private readonly ISightsAndIconsData sightsDb;
        public MySightsAndIconsModel Sights{ get; set; }
        public DeleteSightsModel(ISightsAndIconsData sightsDb)
        {
            this.sightsDb = sightsDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? Id)
        {
            //sightsDb.(Id.Value);

            return RedirectToPage("Tenders");
        }
    }
}
