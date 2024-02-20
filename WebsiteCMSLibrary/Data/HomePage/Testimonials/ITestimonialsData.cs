using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Testimonials
{
	public interface ITestimonialsData
	{
		void AddTestimonial(MyTestimonialModel test);
		List<MyTestimonialModel> AllTestimonials();
		void DeleteTestimonial(int Id);
		MyAnnouncementModel GetTestimonialDetails(int Id);
		void UpdateTestimonial(MyTestimonialModel test);
	}
}