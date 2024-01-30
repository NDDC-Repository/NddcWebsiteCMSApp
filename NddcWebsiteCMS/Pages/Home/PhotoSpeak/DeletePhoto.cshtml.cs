using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;

namespace NddcWebsiteCMS.Pages.Home.PhotoSpeak
{
    public class DeletePhotoModel : PageModel
    {
        private readonly IPhotoSpeakData homeDb;

        public DeletePhotoModel(IPhotoSpeakData homeDb)
        {
            this.homeDb = homeDb;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? Id)
        {
            homeDb.DeleteUpdate(Id.Value);

            return RedirectToPage("AllPhotos");
        }
    }
}
