using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Adverts
{
    public class DeleteTenderModel : PageModel
    {
        private readonly ITendersData tenderDb;
        public MyTenderModel Tender { get; set; }
        public DeleteTenderModel(ITendersData tenderDb)
        {
            this.tenderDb = tenderDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? Id)
        {
            tenderDb.DeleteTender(Id.Value);

            return RedirectToPage("Tenders");
        }
    }
}
