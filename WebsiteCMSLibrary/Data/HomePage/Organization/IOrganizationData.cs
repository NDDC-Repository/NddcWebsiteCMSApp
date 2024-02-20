using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Organization
{
	public interface IOrganizationData
	{
		MyOrganizationModel GetOrganizationDetails(int Id);
		void UpdateOrganization(MyOrganizationModel org);
	}
}