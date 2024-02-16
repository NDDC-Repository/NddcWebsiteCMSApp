using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Videos
{
	public class SqlVideos : IVideoData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlVideos(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddVideo(MyVideoModel video)
        {
            video.DateAdded = DateTime.Now;
            video.AddedBy = "Admin";

            db.SaveData("Insert Into Videos (VideoTitle, VideoDesc, YoutubeUrl, DateAdded, AddedBy) values(@VideoTitle, @VideoDesc, @YoutubeUrl, @DateAdded, @AddedBy)", new { video.VideoTitle, video.VideoDesc, video.YoutubeUrl, video.DateAdded, video.AddedBy }, connectionStringName, false);
        }
        public List<MyVideoModel> AllVideos()
        {
            return db.LoadData<MyVideoModel, dynamic>("Select Id, VideoTitle, VideoDesc, YoutubeUrl, DateAdded From Videos Order By Id DESC", new { }, connectionStringName, false).ToList();
        }

		public MyVideoModel GetVideoDetails(int Id)
		{
            return db.LoadData<MyVideoModel, dynamic>("Select Id, VideoTitle, VideoDesc, YoutubeUrl, DateAdded From Videos Where Id = @Id", new { Id = Id }, connectionStringName, false).FirstOrDefault();
		}

		public void DeleteVideo(int id)
        {
            db.SaveData("Delete Videos Where Id = @Id", new { Id = id }, connectionStringName, false);
        }
        public void EditVideo(MyVideoModel video)
        {
            db.SaveData("Update Videos Set VideoTitle = @VideoTitle, VideoDesc = @VideoDesc, YoutubeUrl = @YoutubeUrl Where Id = @Id", new { video.VideoTitle, video.VideoDesc, video.YoutubeUrl, video.Id }, connectionStringName, false);
        }
    }
}
