using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Announcement;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Announcements
{
    public class AddAnnouncementsModel : PageModel
    {
		private readonly IAnnouncmentData ancDb;

        [BindProperty]
        public MyAnnouncementModel Announcement { get; set; }

        public AddAnnouncementsModel(IAnnouncmentData ancDb)
        {
			this.ancDb = ancDb;
		}
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            ancDb.AddAnnouncement(Announcement);

            return RedirectToPage("AllAnnouncements");
        }

    }
}
