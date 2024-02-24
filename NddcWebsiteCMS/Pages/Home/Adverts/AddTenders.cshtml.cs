using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Adverts
{
    public class AddTendersModel : PageModel
    {
        private readonly ITendersData tenderDb;
        [BindProperty]
        public MyTenderModel Tender { get; set; }
        public AddTendersModel(ITendersData tenderDb)
        {
            this.tenderDb = tenderDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            tenderDb.AddTender(Tender);

            return RedirectToPage("Tenders");
        }
    }
}
