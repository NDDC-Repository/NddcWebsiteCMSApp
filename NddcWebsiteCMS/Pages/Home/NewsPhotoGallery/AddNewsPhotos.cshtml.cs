using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.NewsPhotoGallery
{
    public class AddNewsPhotosModel : PageModel
    {
        private readonly INewsData galDb;

        [BindProperty]
        public MyNewsPhotoGalleryModel Gallery { get; set; }

        public AddNewsPhotosModel(INewsData galDb)
        {
            this.galDb = galDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            galDb.AddNewsPhotoGallery(Gallery);
            return RedirectToPage("AllNewsPhotos");
        }
    }
}
