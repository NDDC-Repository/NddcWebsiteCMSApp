using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.HomePage
{
	public class MyNewsPhotoGalleryModel
	{
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
