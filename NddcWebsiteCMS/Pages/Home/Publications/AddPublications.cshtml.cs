using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Publications;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Publications
{
    public class AddPublicationsModel : PageModel
    {
        private readonly IPublicationsData pubDb;

        [BindProperty]
        public MyPublicationModel Publication { get; set; }

        public AddPublicationsModel(IPublicationsData pubDb)
        {
            this.pubDb = pubDb;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            pubDb.AddPublication(Publication);
            return RedirectToPage("AllPublications");
        }
    }
}
