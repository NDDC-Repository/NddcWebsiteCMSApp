using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.HomePage
{
    public class MyPublicationModel
    {
        public int Id { get; set; }
        public string PubTitle { get; set; }
        public string PubSummary { get; set; }
        public string PubThumbImage { get; set; }
        public string PubUploadUrl { get; set; }
        public DateTime DateUploaded { get; set; }
        public string UploadedBy { get; set; }
    }
}
