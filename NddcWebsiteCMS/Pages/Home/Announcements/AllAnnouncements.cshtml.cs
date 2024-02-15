using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Announcement;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Announcements
{
    public class AllAnnouncementsModel : PageModel
    {
		private readonly IAnnouncmentData ancDb;
        public List<MyAnnouncementModel> Announcements  { get; set; }

        public AllAnnouncementsModel(IAnnouncmentData ancDb)
        {
			this.ancDb = ancDb;
		}
        public void OnGet()
        {
            Announcements = ancDb.AllAnnouncments();
        }
    }
}
