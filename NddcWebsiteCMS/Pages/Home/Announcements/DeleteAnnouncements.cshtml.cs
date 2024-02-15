using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Announcement;

namespace NddcWebsiteCMS.Pages.Home.Announcements
{
    public class DeleteAnnouncementsModel : PageModel
    {
        private readonly IAnnouncmentData ancDb;

        public DeleteAnnouncementsModel(IAnnouncmentData ancDb)
        {
            this.ancDb = ancDb;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(int? Id)
        {
            ancDb.DeleteAnnouncement(Id.Value);

            return RedirectToPage("AllAnnouncements");
        }
    }
}
