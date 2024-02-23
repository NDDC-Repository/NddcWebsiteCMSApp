using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Testimonial
{
    public class Edit_TestimonialModel : PageModel
    {
        private readonly ITestimonialsData testDb;

        [BindProperty(SupportsGet = true)]

        public MyTestimonialModel Testimonial { get; set; }

        public Edit_TestimonialModel(ITestimonialsData testDb)
        {
            this.testDb = testDb;
        }
        public void OnGet(int? Id)
        {
            Testimonial = testDb.GetTestimonialDetails(Id.Value);
        }
        public IActionResult OnPost(int? Id)
        {
            Testimonial.Id = Id.Value;
            testDb.UpdateTestimonial(Testimonial);

            return RedirectToPage("AllTestimonials");
        }
    }
}
