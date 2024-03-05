using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Publications;

namespace NddcWebsiteCMS.Pages.Home.Publications
{

    public class DeletePublicationsModel : PageModel
    {
        private readonly IPublicationsData pubDb;

        public DeletePublicationsModel(IPublicationsData pubDb)
        {
            this.pubDb = pubDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? Id)
        {
            pubDb.DeletePublication(Id.Value);

            return RedirectToPage("AllPublications");
        }
    }
}



