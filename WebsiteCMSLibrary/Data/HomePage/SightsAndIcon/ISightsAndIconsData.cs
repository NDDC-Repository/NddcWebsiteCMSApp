using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.SightsAndIcon
{
	public interface ISightsAndIconsData
	{
		void AddSightsAndIcons(MySightsAndIconsModel sight);
		List<MySightsAndIconsModel> AllSightsAndIcons();
		void DeleteAnnouncement(int Id);
		MySightsAndIconsModel GetSightAndIconsDetails(int Id);
		void UpdateSightsAndIcons(MySightsAndIconsModel sight);
	}
}