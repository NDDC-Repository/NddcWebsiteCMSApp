using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Testimonial
{
    public class Add_TestimonialModel : PageModel
    {
		private readonly ITestimonialsData testDb;
        [BindProperty]
        public MyTestimonialModel Testimonial { get; set; }
        public Add_TestimonialModel(ITestimonialsData testDb)
        {
			this.testDb = testDb;
		}
        public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
            Testimonial.DateAdded = DateTime.Now;

			testDb.AddTestimonial(Testimonial);

			return RedirectToPage("AllTestimonials");
		}
	}
}
