using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;
using WebsiteCMSLibrary.Helper;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Model.HomePage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace NddcWebsiteCMS.Pages.Home.PhotoSpeak
{
    public class EditPhotosModel : PageModel
    {
        private readonly IPhotoSpeakData photoDb;
		private readonly IAzureStorage aws;
		private readonly IHelperData helpDb;

		[BindProperty(SupportsGet = true)]
        public MyPhotoSpeakModel Photo { get; set; }
		public IFormFile Upload { get; set; }
		public EditPhotosModel(IPhotoSpeakData photoDb, IAzureStorage aws, IHelperData helpDb)
        {
            this.photoDb = photoDb;
			this.aws = aws;
			this.helpDb = helpDb;
		}
        public void OnGet(int? Id)
        {
            Photo = photoDb.GetPhotoSpeakDetails(Id.Value);
        }
        public async Task<IActionResult> OnPost(int? Id)
        {
			if (Upload is not null)
			{
				string fileName = "Photos/" + helpDb.RandomNumber(0, 1000) + Upload.FileName;
				MyBlobResponseModel? response = await aws.UploadAndResizeImageAsync(Upload, 555, 525, fileName);;
				Photo.ImageUrl = response.Blob.Uri;
			}
			Photo.Id = Id.Value;
            photoDb.EditPhotoSpeak(Photo);
            return RedirectToPage("AllPhotos");
        }
    }
}
