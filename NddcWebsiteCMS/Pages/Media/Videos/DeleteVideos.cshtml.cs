using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Videos;

namespace NddcWebsiteCMS.Pages.Media.Videos
{
    public class DeleteVideosModel : PageModel
    {
        private readonly IVideoData videoDb;

        public DeleteVideosModel(IVideoData videoDb)
        {
            this.videoDb = videoDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? Id)
        {
            videoDb.DeleteVideo(Id.Value);

            return RedirectToPage("AllVideos");
        }
    }
}
