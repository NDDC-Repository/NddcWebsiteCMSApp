using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class AddSightsModel : PageModel
    {
        private readonly ISightsAndIconsData sightsDb;
        private readonly IAzureStorage storage;

        [BindProperty]
        public MySightsAndIconsModel Sights { get; set; }
        
        [BindProperty]
        public IFormFile Upload { get; set; }
        public AddSightsModel(ISightsAndIconsData sightsDb, IAzureStorage storage)
        {
            this.sightsDb = sightsDb;
            this.storage = storage;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            string fileName = "Photos/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
            MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
            Sights.ImageUrl = response.Blob.Uri;
            Sights.DateAdded = DateTime.Now;
            Sights.AddedBy = "Admin";

            sightsDb.AddSightsAndIcons(Sights);

            return RedirectToPage("AllSights");
        }
    }
}
