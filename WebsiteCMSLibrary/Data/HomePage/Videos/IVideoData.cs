using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Videos
{
    public interface IVideoData
    {
        void AddVideo(MyVideoModel video);
        List<MyVideoModel> AllVideos();
        void DeleteVideo(int id);
        void EditVideo(MyVideoModel video);
		MyVideoModel GetVideoDetails(int Id);
	}
}