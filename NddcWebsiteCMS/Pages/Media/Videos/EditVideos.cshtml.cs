using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Videos;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Media.Videos
{
    public class EditVideosModel : PageModel
    {
		private readonly IVideoData videoDb;
        [BindProperty(SupportsGet = true)]
        public MyVideoModel Video { get; set; }
        public EditVideosModel(IVideoData videoDb)
        {
			this.videoDb = videoDb;
		}
        public void OnGet( int? Id)
        {
            Video = videoDb.GetVideoDetails(Id.Value);
		}
		public IActionResult OnPost(int? Id)
        {
            Video.Id = Id.Value;
            videoDb.EditVideo(Video);
            return RedirectToPage("AllVideos");

		}

	}
}
