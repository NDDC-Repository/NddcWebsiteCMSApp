using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Announcement;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Announcements
{
    public class EditAnnouncementsModel : PageModel
    {
        private readonly IAnnouncmentData ancDb;
        [BindProperty (SupportsGet = true)]
        public MyAnnouncementModel Announcement { get; set; }

        public EditAnnouncementsModel(IAnnouncmentData ancDb)
        {
            this.ancDb = ancDb;
        }
        
        public void OnGet(int? Id)
        {
            Announcement = ancDb.GetAnnouncementDetails(Id.Value);
        }
        public IActionResult OnPost(int? Id)
        {
            Announcement.Id = Id.Value;
            ancDb.UpdateAnnouncement(Announcement);

            return RedirectToPage("AllAnnouncements");
        }
    }
}
