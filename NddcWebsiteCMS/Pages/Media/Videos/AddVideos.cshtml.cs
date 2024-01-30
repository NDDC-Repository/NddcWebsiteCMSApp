using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Videos;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Videos
{
    public class AddVideosModel : PageModel
    {
        private readonly IVideoData videoDb;
        [BindProperty]
        public MyVideoModel Video { get; set; }

        public AddVideosModel(IVideoData videoDb)
        {
            this.videoDb = videoDb;
        }
        public IActionResult OnPost()
        {
            string url = Video.YoutubeUrl;
            string trimmedUrl = url.Trim(new Char[] { 'h', 't', 't', 'p', 's', ':', '/', '/', 'y', 'o', 'u', 't', 'u', '.', 'b', 'e', '/' });
            Video.YoutubeUrl = trimmedUrl;

            videoDb.AddVideo(Video);

            return RedirectToPage("AllVideos");
        }
    }
}
