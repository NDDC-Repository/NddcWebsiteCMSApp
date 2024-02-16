using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.PhotoSpeak
{
    public class EditPhotosModel : PageModel
    {
        private readonly IPhotoSpeakData photoDb;
        [BindProperty(SupportsGet = true)]
        public MyPhotoSpeakModel Photo { get; set; }
        public EditPhotosModel(IPhotoSpeakData photoDb)
        {
            this.photoDb = photoDb;
        }
        public void OnGet(int? Id)
        {
            Photo = photoDb.GetPhotoSpeakDetails(Id.Value);
        }
        public IActionResult OnPost(int? Id)
        {
            Photo.Id = Id.Value;
            photoDb.EditPhotoSpeak(Photo);
            return RedirectToPage("AllPhotos");
        }
    }
}
