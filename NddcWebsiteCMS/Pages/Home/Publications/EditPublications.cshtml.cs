using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Publications;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.Publications
{
    public class EditPublicationsModel : PageModel
    {
        private readonly IPublicationsData pubDb;
        private readonly IAzureStorage storage;
        [BindProperty(SupportsGet = true)]
        public MyPublicationModel Publication { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public EditPublicationsModel(IPublicationsData pubDb, IAzureStorage storage)
        {
            this.pubDb = pubDb;
            this.storage = storage;
        }
        public void OnGet()
        {
        
        }
    }
}
