using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Videos;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Videos
{
    public class AllVideosModel : PageModel
    {
        private readonly IVideoData videoDb;

        public List<MyVideoModel> Videos { get; set; }

        public AllVideosModel(IVideoData videoDb)
        {
            this.videoDb = videoDb;
        }
        public void OnGet()
        {
            Videos = videoDb.AllVideos();
        }
    }
}
