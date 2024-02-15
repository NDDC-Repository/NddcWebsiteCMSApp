using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Announcement
{
	public class SQLAnnouncment : IAnnouncmentData
	{
		private readonly ISqlDataAccess db;
		private const string connectionStringName = "SqlDb";

		public SQLAnnouncment(ISqlDataAccess db)
		{
			this.db = db;
		}

		public void AddAnnouncement(MyAnnouncementModel anc)
		{
			DateTime dateAdded = DateTime.Now;
			string addedBy = "Admin";
			db.SaveData("Insert Into Announcements (Title, StartDate, EndDate, Details, DateAdded, AddedBy) values(@Title, @StartDate, @EndDate, @Details, @DateAdded, @AddedBy)", new { Title = anc.Title, StartDate = anc.StartDate, EndDate = anc.EndDate, Details = anc.Details, DateAdded = dateAdded, AddedBy = addedBy }, connectionStringName, false);
		}
		public List<MyAnnouncementModel> AllAnnouncments()
		{
			return db.LoadData<MyAnnouncementModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, Title, StartDate, EndDate, Details from Announcements Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public void UpdateAnnouncement(MyAnnouncementModel anc)
		{
			db.SaveData("Update Announcements Set Title = @Title, StartDate = @StartDate, EndDate = @EndDate, Details = @Details Where Id = @Id", new { Id = anc.Id, Title = anc.Title, StartDate = anc.StartDate, EndDate = anc.EndDate, Details = anc.Details }, connectionStringName, false);
		}
		public MyAnnouncementModel GetAnnouncementDetails(int Id)
		{
            return db.LoadData<MyAnnouncementModel, dynamic>("Select Title, StartDate, EndDate, Details From Announcements Where Id = @Id", new { Id = Id }, connectionStringName, false).FirstOrDefault();
        }
		public void DeleteAnnouncement(int Id)
		{
            db.SaveData("Delete Announcements Where Id = @Id", new { Id = Id }, connectionStringName, false);
        }

	}
}
