using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.HomePage
{
    public class MyTestimonialModel
    {
        public int Id { get; set; }
        public string TestimonialBy { get; set; }
        public string Occupation { get; set; }
        public string Testimonial { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
