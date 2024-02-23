using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.NewsPhotoGallery
{
    public class AllNewsPhotosModel : PageModel
    {
        private readonly INewsData galDb;
        private readonly IConfiguration config;

        public List<MyNewsPhotoGalleryModel> GalleryList { get; set; }
        public int NId { get; set; }

        
        public readonly string _bucketName;

        public AllNewsPhotosModel(INewsData galDb, IConfiguration config)
        {
            this.galDb = galDb;
            _bucketName = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet(int? Id)
        {
           NId = Id.Value;
           GalleryList = galDb.AllPhotoGalleryImages(Id.Value);
        }
    }
}
