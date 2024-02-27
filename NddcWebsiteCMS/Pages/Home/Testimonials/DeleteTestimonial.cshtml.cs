using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;

namespace NddcWebsiteCMS.Pages.Home.Testimonials
{
    public class DeleteTestimonialModel : PageModel
    {
        private readonly ITestimonialsData testDb;
        public DeleteTestimonialModel(ITestimonialsData testDb)
        {
            this.testDb = testDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? Id)
        {
            testDb.DeleteTestimonial(Id.Value);

            return RedirectToPage("AllTestimonials");
        }
    }
}
