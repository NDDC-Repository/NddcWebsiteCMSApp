using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Publications
{
    public class SqlPublications : IPublicationsData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlPublications(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddPublication(MyPublicationModel pub)
        {
            pub.DateUploaded = DateTime.Now;
            pub.UploadedBy = "Admin";

            db.SaveData("Insert Into Publications (PubTitle, PubSummary, PubThumbImage, PubUploadUrl, DateUploaded, UploadedBy) values(@PubTitle, @PubSummary, @PubThumbImage, @PubUploadUrl, @DateUploaded, @UploadedBy)", new { pub.PubTitle, pub.PubSummary, pub.PubUploadUrl, pub.DateUploaded, pub.UploadedBy }, connectionStringName, false);
        }
        public List<MyPublicationModel> AllPublications()
        {
            return db.LoadData<MyPublicationModel, dynamic>("Select PubId, PubTitle, PubSummary, PubThumbImage, PubUploadUrl, DateUploaded From Publications Order By PubId DESC", new { }, connectionStringName, false).ToList();
        }
		public MyTenderModel ViewPublicationDetails(int Id)
		{
			return db.LoadData<MyTenderModel, dynamic>("Select PubId, PubTitle, PubSummary, PubThumbImage, PubUploadUrl, DateUploaded From Publications Where PubId = @Id", new { PubId = Id }, connectionStringName, false).FirstOrDefault();
		}
		public void DeletePublication(int id)
        {
            db.SaveData("Delete Publications Where PubId = @Id", new { Id = id }, connectionStringName, false);
        }
        public void EditPublication(MyPublicationModel pub)
        {
            db.SaveData("Update Publications Set PubTitle = @PubTitle, PubSummary = @PubSummary, PubThumImage = @PubThumbImage, PubUploadUrl = @PubUploadUrl Where PubId = @PubId", new { pub.PubTitle, pub.PubSummary, pub.PubThumbImage, pub.PubUploadUrl, pub.PubId }, connectionStringName, false);
        }
    }
}
