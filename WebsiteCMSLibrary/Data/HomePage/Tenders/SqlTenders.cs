using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Tenders
{
    public class SqlTenders : ITendersData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlTenders(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddTender(MyTenderModel tender)
        {
            tender.AddedBy = "Admin";

            db.SaveData("Insert Into Tenders (Title, Category, Details, DocumentUrl, AdvertDate, DeadlineDate, AddedBy) values(@Title, @Category, @Details, @DocumentUrl, @AdvertDate, @DeadlineDate, @AddedBy)", new { tender.Title, tender.Category, tender.Details, tender.DocumentUrl, tender.AdvertDate, tender.DeadlineDate, tender.AddedBy }, connectionStringName, false);
        }
        public List<MyTenderModel> AllTenders()
        {
            return db.LoadData<MyTenderModel, dynamic>("Select Id, Titel, Category, DocumentUrl, AdvertDate, DeadlioneDate From Tenders Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
        public MyTenderModel ViewTenderDetails(int Id)
        {
            return db.LoadData<MyTenderModel, dynamic>("Select Id, Titel, Category, Details, DocumentUrl, AdvertDate, DeadlioneDate From Tenders Where Id = @Id Order By Id DESC", new { Id }, connectionStringName, false).FirstOrDefault();
        }

        public void DeleteTender(int id)
        {
            db.SaveData("Delete Tenders Where Id = @Id", new { Id = id }, connectionStringName, false);
        }
        public void EditTender(MyTenderModel tender)
        {
            db.SaveData("Update Tenders Set Title = @Title, Category = @Category, Details = @Details, DocumentUrl = @DocumentUrl, AdvertDate = @AdvertDate, DeadlineDate = @DeadlineDate Where Id = @Id", new { tender.Title, tender.Category, tender.Details, tender.DocumentUrl, tender.AdvertDate, tender.DeadlineDate, tender.Id }, connectionStringName, false);
        }
    }
}
