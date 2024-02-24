using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.SightsAndIcon
{
	public class SQLSightsAndIcons : ISightsAndIconsData
	{
		private readonly ISqlDataAccess db;
		private const string connectionStringName = "SqlDb";

		public SQLSightsAndIcons(ISqlDataAccess db)
		{
			this.db = db;
		}
		public void AddSightsAndIcons(MySightsAndIconsModel sight)
		{
			DateTime dateAdded = DateTime.Now;
			string addedBy = "Admin";
			db.SaveData("Insert Into Announcements (Title, Summary, ImageUrl, Details, DateAdded, AddedBy) values(@Title, @Summary, @ImageUrl, @Details, @DateAdded, @AddedBy)", new { Titel = sight.Title, Summary = sight.Summary, ImageUrl = sight.ImageUrl, Details = sight.Details, DateAdded = dateAdded, AddedBy = addedBy }, connectionStringName, false);
		}
		public List<MySightsAndIconsModel> AllSightsAndIcons()
		{
			return db.LoadData<MySightsAndIconsModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, Title, Summary, ImageUrl, Details, DateAdded from SightsAndIcons Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public void UpdateSightsAndIcons(MySightsAndIconsModel sight)
		{
			db.SaveData("Update SightsAndIcons Set Title = @Title, Summary = @Summary, ImageUrl = @ImageUrl, Details = @Details Where Id = @Id", new { Title = sight.Title, Summary = sight.Summary, ImageUrl = sight.ImageUrl, Details = sight.Details, Id = sight.Id }, connectionStringName, false);
		}
		public MySightsAndIconsModel GetSightAndIconsDetails(int Id)
		{
			return db.LoadData<MySightsAndIconsModel, dynamic>("Select Title, Summary, ImageUrl, Details From SightsAndIcons Where Id = @Id", new { Id = Id }, connectionStringName, false).FirstOrDefault();
		}
		public void DeleteAnnouncement(int Id)
		{
			db.SaveData("Delete SightsAndIcons Where Id = @Id", new { Id = Id }, connectionStringName, false);
		}
	}
}
