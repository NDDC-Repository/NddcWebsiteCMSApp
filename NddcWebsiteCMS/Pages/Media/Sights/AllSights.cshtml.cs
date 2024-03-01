using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class AllSightsModel : PageModel
    {
        private readonly ISightsAndIconsData sightsDb;
        private readonly IConfiguration config;
        public readonly string _bucketName;
        public List<MySightsAndIconsModel> Sights { get; set; }
        public AllSightsModel(ISightsAndIconsData sightsDb, IConfiguration config)
        {
            this.sightsDb = sightsDb;
            _bucketName = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            Sights = sightsDb.AllSightsAndIcons();
        }
    }
}
