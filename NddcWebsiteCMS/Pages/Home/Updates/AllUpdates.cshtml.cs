using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Updates;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Updates
{
    public class AllUpdatesModel : PageModel
    {
        private readonly IUpdatesData updateDb;
        public List<MyUpdateModel> Updates { get; set; }
        public readonly string _container;

        public AllUpdatesModel(IUpdatesData updateDb, IConfiguration config)
        {
            this.updateDb = updateDb;
            _container = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            Updates = updateDb.AllUpdates();
        }
    }
}
