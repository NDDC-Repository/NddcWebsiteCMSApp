using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.PhotoSpeak
{
    public class AddPhotographModel : PageModel
    {
        private readonly IPhotoSpeakData photoDb;
        private readonly IAzureStorage storage;
        private readonly IHelperData helperDb;

        [BindProperty (SupportsGet = true)]
        public MyPhotoSpeakModel Photo { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public AddPhotographModel(IPhotoSpeakData photoDb, IAzureStorage storage, IHelperData helperDb)
        {
            this.photoDb = photoDb;
            this.storage = storage;
            this.helperDb = helperDb;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string fileName = "Photos/" + helperDb.RandomNumber(0, 1000) +  Upload.FileName;
            //MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
            MyBlobResponseModel? response = await storage.UploadAndResizeImageAsync(Upload, 555, 525, fileName);
            Photo.ImageUrl = response.Blob.Uri;
            Photo.DateAdded = DateTime.Now;
            Photo.AddedBy = "Admin";

            photoDb.AddPhotoSpeak(Photo);

            return RedirectToPage("AllPhotos");
        }
    }
}
