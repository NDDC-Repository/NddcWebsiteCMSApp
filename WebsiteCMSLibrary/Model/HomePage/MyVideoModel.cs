using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.HomePage
{
    public class MyVideoModel
    {
        public int Id { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDesc { get; set; }
        public string YoutubeUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
