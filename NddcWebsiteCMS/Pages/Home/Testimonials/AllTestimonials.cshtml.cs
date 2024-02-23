using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteCMSLibrary.Data.HomePage.Testimonials;
using WebsiteCMSLibrary.Model.HomePage;

namespace NddcWebsiteCMS.Pages.Home.Testimonial
{
    public class All_TestimonialsModel : PageModel
    {
		private readonly ITestimonialsData testDb;
        public List<MyTestimonialModel> Testimonials { get; set; }
        public All_TestimonialsModel(ITestimonialsData testDb)
        {
			this.testDb = testDb;
		}
        public void OnGet()
        {
            Testimonials= testDb.AllTestimonials();
        }
    }
}
