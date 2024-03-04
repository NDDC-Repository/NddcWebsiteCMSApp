using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Publications;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Publications
{
    public class AllPublicatiosModel : PageModel
    {
        private readonly IPublicationsData pubDb;
        public List<MyPublicationModel> Publications { get; set; }
        public readonly string _bucketName;
        public AllPublicatiosModel(IPublicationsData pubDb, IConfiguration config)
        {
            this.pubDb = pubDb;
            _bucketName = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            Publications = pubDb.AllPublications();
        }
    }
}
