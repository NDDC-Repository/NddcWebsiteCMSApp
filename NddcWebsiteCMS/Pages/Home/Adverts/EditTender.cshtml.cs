using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Tenders;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Adverts
{
    public class EditTenderModel : PageModel
    {
        private readonly ITendersData tenderDb;
        [BindProperty(SupportsGet = true)]
        public MyTenderModel Tender { get; set; }
        public EditTenderModel(ITendersData tenderDb)
        {
            this.tenderDb = tenderDb;
        }
        public void OnGet(int? Id)
        {
            Tender = tenderDb.ViewTenderDetails(Id.Value);
        }
        public IActionResult OnPost(int? Id)
        {
            Tender.Id = Id.Value;
            tenderDb.EditTender(Tender);

            return RedirectToPage("Tenders");
        }
    }
}
