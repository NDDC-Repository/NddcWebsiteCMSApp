using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Testimonials
{
	public class SQLTestimonials : ITestimonialsData
	{
		private readonly ISqlDataAccess db;
		private const string connectionStringName = "SqlDb";

		public SQLTestimonials(ISqlDataAccess db)
		{
			this.db = db;
		}
		public void AddTestimonial(MyTestimonialModel test)
		{
			DateTime dateAdded = DateTime.Now;
			string addedBy = "Admin";
			db.SaveData("Insert Into Testimonial (TestimonialBy, Occupation, Testimonial, DateAdded, AddedBy) values(@TestimonialBy, @Occupation, @Testimonial, @DateAdded, @AddedBy)", new { TestimonialBy = test.TestimonialBy, Occupation = test.Occupation, Testimonial = test.Testimonial, ImageUrl = test.ImageUrl, DateAdded = test.DateAdded, AddedBy = test.AddedBy }, connectionStringName, false);
		}
		public List<MyTestimonialModel> AllTestimonials()
		{
			return db.LoadData<MyTestimonialModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, TestimonialBy, Occupation, Testimonial from Testimonial Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public void UpdateTestimonial(MyTestimonialModel test)
		{
			db.SaveData("Update Testimonial Set TestimonialBy = @TestimonialBy, Occupation = @Occupation, Testimonial = @Testimonial Where Id = @Id", new { TestimonialBy = test.TestimonialBy, Occupation = test.Occupation, Testimonial = test.Testimonial }, connectionStringName, false);
		}
		public MyAnnouncementModel GetTestimonialDetails(int Id)
		{
			return db.LoadData<MyAnnouncementModel, dynamic>("Select TestimonialBy, Testimonial, Occupation From Testimonial Where Id = @Id", new { Id = Id }, connectionStringName, false).FirstOrDefault();
		}
		public void DeleteTestimonial(int Id)
		{
			db.SaveData("Delete Testimonial Where Id = @Id", new { Id = Id }, connectionStringName, false);
		}
	}
}
