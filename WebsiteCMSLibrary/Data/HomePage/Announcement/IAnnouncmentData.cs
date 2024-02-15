using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Announcement
{
	public interface IAnnouncmentData
	{
		void AddAnnouncement(MyAnnouncementModel anc);
		List<MyAnnouncementModel> AllAnnouncments();
        void DeleteAnnouncement(int Id);
        MyAnnouncementModel GetAnnouncementDetails(int Id);
        void UpdateAnnouncement(MyAnnouncementModel anc);
	}
}