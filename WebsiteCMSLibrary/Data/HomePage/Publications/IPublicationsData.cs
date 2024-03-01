using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Publications
{
    public interface IPublicationsData
    {
        void AddPublication(MyPublicationModel pub);
        List<MyPublicationModel> AllPublications();
        void DeletePublication(int id);
        void EditPublication(MyPublicationModel pub);
		MyTenderModel ViewPublicationDetails(int Id);
	}
}