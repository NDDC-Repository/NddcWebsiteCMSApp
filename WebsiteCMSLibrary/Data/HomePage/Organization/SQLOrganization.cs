using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Organization
{
	public class SQLOrganization : IOrganizationData
	{
		private readonly ISqlDataAccess db;
		private const string connectionStringName = "SqlDb";

		public SQLOrganization(ISqlDataAccess db)
		{
			this.db = db;
		}

		public void UpdateOrganization(MyOrganizationModel org)
		{
			db.SaveData("Update Organization Set Email = @Email, Phone = @Phone, Address = @Address, Facebook = @Facebook, Twitter = @Twitter, Linkdin = @Linkdin, Instagram = @Instagram, Youtube = @Youtube,  Where Id = @Id", new { Email = org.Email, Phone = org.Phone, Address = org.Address, Facebook = org.Facebook, Twitter = org.Twitter, Linkdin = org.Linkdin, Instagram = org.Instagram, Youtube = org.Youtube }, connectionStringName, false);
		}
		public MyOrganizationModel GetOrganizationDetails(int Id)
		{
			return db.LoadData<MyOrganizationModel, dynamic>("Select Email, Phone, Address, Facebook, Twitter, Linkdin, Instagram, Youtube From Organization Where Id = @Id", new { Id = Id }, connectionStringName, false).FirstOrDefault();
		}
	}
}
