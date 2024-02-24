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
        public TendersModel(ITendersData tenderDb)
        {
            this.tenderDb = tenderDb;
        }
        public void OnGet()
        {
            Tenders = tenderDb.AllTenders();
        }
    }
}
