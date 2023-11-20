using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCMSLibrary.Model.AzureStorage
{
    public class MyBlobResponseModel
    {
        public string? Status { get; set; }
        public bool Error { get; set; }
        public MyBlobModel Blob { get; set; }

        public MyBlobResponseModel()
        {
            Blob = new MyBlobModel();
        }
    }
}
