using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class AllSightsModel : PageModel
    {
        private readonly ISightsAndIconsData sightsDb;
        public List<MySightsAndIconsModel> Sights { get; set; }
        public AllSightsModel(ISightsAndIconsData sightsDb)
        {
            this.sightsDb = sightsDb;
        }
        public void OnGet()
        {
            Sights = sightsDb.AllSightsAndIcons();
        }
    }
}
