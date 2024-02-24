using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class EditSightsModel : PageModel
    {
        private readonly ISightsAndIconsData sightsDb;
        [BindProperty(SupportsGet = true)]
        public MySightsAndIconsModel Sights { get; set; }
        public EditSightsModel(ISightsAndIconsData sightsDb)
        {
            this.sightsDb = sightsDb;
        }
        public void OnGet(int? Id)
        {
            Sights = sightsDb.GetSightAndIconsDetails(Id.Value);
        }
        public IActionResult OnPost(int? Id)
        {
            Sights.Id = Id.Value;
            sightsDb.UpdateSightsAndIcons(Sights);

            return RedirectToPage("AllAnnouncements");
        }
    }
}
