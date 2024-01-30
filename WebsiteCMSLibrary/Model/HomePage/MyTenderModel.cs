using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.HomePage
{
    public class MyTenderModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime AdvertDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string AddedBy { get; set; }
    }
}
