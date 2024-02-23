using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Abstractions;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.NewsPhotoGallery
{
    public class AddNewsPhotosModel : PageModel
    {
        private readonly INewsData galDb;
        private readonly IAzureStorage storage;
        private readonly IHelperData helpDb;

        [BindProperty]
        public MyNewsPhotoGalleryModel Gallery { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public AddNewsPhotosModel(INewsData galDb, IAzureStorage storage, IHelperData helpDb)
        {
            this.galDb = galDb;
            this.storage = storage;
            this.helpDb = helpDb;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(int? Id)
        {
            string fileName = "Photos/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload.FileName));
            // + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name)
            //MyBlobResponseModel? response = await storage.UploadAsync(Upload, fileName);
            MyBlobResponseModel ? response = await storage.UploadAsync(Upload, fileName);
            Gallery.ImageUrl = response.Blob.Uri;
            Gallery.DateAdded = DateTime.Now;
            Gallery.AddedBy = "Admin";
            Gallery.NewsId = Id.Value;

            galDb.AddNewsPhotoGallery(Gallery);
            return RedirectToPage("AllNewsPhotos", new { Id = Id.Value});
        }
    }
}
