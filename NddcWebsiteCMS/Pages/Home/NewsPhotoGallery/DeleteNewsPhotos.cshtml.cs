using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;

namespace NddcWebsiteCMS.Pages.Home.NewsPhotoGallery
{
    public class DeleteNewsPhotosModel : PageModel
    {
        private readonly INewsData galDb;

        public DeleteNewsPhotosModel(INewsData galDb)
        {
            this.galDb = galDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? Id, int? nid)
        {
            galDb.DeleteNewsPhotoGallery(Id.Value);
            return RedirectToPage("AllNewsPhotos", new { Id = nid.Value });
        }
        }
}
