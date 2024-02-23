using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.NewsPhotoGallery
{
    public class AllNewsPhotosModel : PageModel
    {
        private readonly INewsData galDb;
        public List<MyNewsPhotoGalleryModel> GalleryList { get; set; }
        public AllNewsPhotosModel(INewsData galDb)
        {
            this.galDb = galDb;
        }
        public void OnGet()
        {
        
        }
    }
}
