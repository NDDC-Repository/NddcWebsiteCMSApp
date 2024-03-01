using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.SightsAndIcon;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Media.Sights
{
    public class EditSightsModel : PageModel
    {
        private readonly IAzureStorage storage;
        private readonly ISightsAndIconsData sightsDb;
        [BindProperty(SupportsGet = true)]
        public MySightsAndIconsModel Sights { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public EditSightsModel(ISightsAndIconsData sightsDb, IAzureStorage storage)
        {
            this.sightsDb = sightsDb;
            this.storage = storage;
        }
        public void OnGet(int? Id)
        {
            Sights = sightsDb.GetSightAndIconsDetails(Id.Value);
        }
        public async Task<IActionResult> OnPost(int? Id)
        {
            if (Upload is not null)
            {
                string fileName = "Photos/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
                MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
                Sights.ImageUrl = response.Blob.Uri;
            }

            Sights.Id = Id.Value;
            sightsDb.UpdateSightsAndIcons(Sights);

            return RedirectToPage("AllSights");
        }
    }
}
