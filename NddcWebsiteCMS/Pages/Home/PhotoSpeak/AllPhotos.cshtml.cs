using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.PhotoSpeak;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.PhotoSpeak
{
    public class AllPhotosModel : PageModel
    {
        private readonly IPhotoSpeakData photoDb;
        private readonly IConfiguration config;
        public readonly string _bucketName;

        public List<MyPhotoSpeakModel> Photos { get; set; }

        public AllPhotosModel(IPhotoSpeakData photoDb, IConfiguration config)
        {
            this.photoDb = photoDb;
            _bucketName = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            
            Photos = photoDb.AllPhotos();
        }
    }
}
