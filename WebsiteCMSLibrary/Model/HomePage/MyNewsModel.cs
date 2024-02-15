using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.HomePage
{
    public class MyNewsModel
    {
        public int NID { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string NewsId { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; } = DateTime.Now;
        public Boolean TimeStamp { get; set; }
        public Boolean Enabled { get; set; }
        public string Type { get; set; }
        public Boolean SetAsSlide { get; set; }
        public string Tags { get; set; }
        public Boolean Archive { get; set; }
        public int Views { get; set; }
        public int Clicks { get; set; }
        public int NDID { get; set; }
        public int CMID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string DisplayFormat { get; set; }
    }
}
