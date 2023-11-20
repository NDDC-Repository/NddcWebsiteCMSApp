using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage
{
    public interface INewsData
    {
        void AddNews(MyNewsModel news);
        List<MyNewsModel> AllNews();
        void DeleteNews(int id);
        List<MyNewsModel> DisplaySlides();
        string GetBreakingNews();
        MyNewsModel GetNewsDetails(int Id);
        List<MyNewsModel> ListHomePageNews();
        void UpdateNews(int id);
    }
}