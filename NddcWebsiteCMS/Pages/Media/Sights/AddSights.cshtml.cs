using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class AddSightsModel : PageModel
    {
        private readonly ISightsAndIconsData sightsDb;
        [BindProperty]
        public MySightsAndIconsModel Sights { get; set; }
        public AddSightsModel(ISightsAndIconsData sightsDb)
        {
            this.sightsDb = sightsDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            sightsDb.AddSightsAndIcons(Sights);

            return RedirectToPage("AllSights");
        }
    }
}
