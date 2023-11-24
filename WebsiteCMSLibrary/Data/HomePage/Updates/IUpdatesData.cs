using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Updates
{
    public interface IUpdatesData
    {
        void AddUpdate(MyUpdateModel update);
        List<MyUpdateModel> AllUpdates();
        void DeleteUpdate(int id);
        List<MyUpdateModel> DisplaySlides();
        void EditUpdate(MyUpdateModel update);
        MyNewsModel GetImageByUpdateCategory(string updateCategory);
        MyUpdateModel UpdatesDetails(int id);
    }
}