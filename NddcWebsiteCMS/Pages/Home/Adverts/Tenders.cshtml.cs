using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Adverts
{
    public class TendersModel : PageModel
    {
        private readonly ITendersData tenderDb;
        public List<MyTenderModel> Tenders { get; set; }
        public readonly string _bucketName;
        public TendersModel(ITendersData tenderDb, IConfiguration config)
        {
            this.tenderDb = tenderDb;
            _bucketName = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            Tenders = tenderDb.AllTenders();
        }
    }
}
