using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage
{
    public interface INewsData
    {
        void AddNews(MyNewsModel news);
		void AddNewsPhotoGallery(MyNewsPhotoGalleryModel news);
		List<MyNewsModel> AllNews();
        void DeleteNews(int id);
		void DeleteNewsPhotoGallery(int id);
		List<MyNewsModel> DisplaySlides();
        string GetBreakingNews();
        string GetLatestNews();
        MyNewsModel GetNewsDetails(int Id);
        List<MyNewsModel> ListHomePageNews();
        void UpdateNews(MyNewsModel news);
    }
}