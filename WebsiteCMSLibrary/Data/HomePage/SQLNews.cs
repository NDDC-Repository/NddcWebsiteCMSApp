using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage
{
    public class SQLNews : INewsData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SQLNews(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddNews(MyNewsModel news)
        {
            db.SaveData("Insert Into News (Subject, Summary, Details, NewsID, ImageUrl, PublishDate, ExpiryDate, TimeStamp, Enabled, Type, SetAsSlide, Archive, NDID, CMID, Datecreated, CreatedBy) values(@Subject, @Summary, @Details, @NewsID, @ImageUrl, @PublishDate, @ExpiryDate, @TimeStamp, @Enabled, @Type, @SetAsSlide, @Archive, @NDID, @CMID, @Datecreated, @CreatedBy)", new { Subject = news.Subject, Summary = news.Summary, Details = news.Details, NewsID = news.NewsId, ImageUrl = news.ImageUrl, PublishDate = news.PublishDate, ExpiryDate = news.ExpiryDate, TimeStamp = news.TimeStamp, Enabled = news.Enabled, Type = news.Type, SetAsSlide = news.SetAsSlide, Archive = news.Archive, NDID = news.NDID, CMID = news.CMID, DateCreated = news.DateCreated, CreatedBy = news.CreatedBy }, connectionStringName, false);
        }
        public List<MyNewsModel> AllNews()
        {
            return db.LoadData<MyNewsModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> ListHomePageNews()
        {
            return db.LoadData<MyNewsModel, dynamic>("select top 3 ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide, from News OrderBy Id DESC", new { }, connectionStringName, false).ToList();
        }
        public string GetBreakingNews()
        {
            return db.LoadData<string, dynamic>("select top 1 Id, Subject from News OrderBy Id DESC", new { }, connectionStringName, false).SingleOrDefault();
        }
        public List<MyNewsModel> DisplaySlides()
        {
            return db.LoadData<MyNewsModel, dynamic>("select top 5 Id, Subject, Summary, ImageUrl from News OrderBy Id DESC", new { }, connectionStringName, false).ToList();
        }
        public MyNewsModel GetNewsDetails(int Id)
        {
            return db.LoadData<MyNewsModel, dynamic>("select NID, Subject, Summary, ImageUrl, PublishDate from News where NID = @NID", new { NID = Id }, connectionStringName, false).SingleOrDefault();
        }
        public void DeleteNews(int id)
        {
            db.SaveData("Delete News Where NID = @NID", new { NID = id }, connectionStringName, false);
        }
        public void UpdateNews(int id)
        {
            db.SaveData("Update News Set Subject = @Subject, Summary = @Summary, NDID = @NDID, Type = @Type, SetAsSlide = @SetAsSlide, PublishDate = @PublishDate, ExpiryDate = @ExpiryDate, ImageUrl = @ImageUrl, Details = @Details Where Id = @Id", new { Id = id }, connectionStringName, false);
        }
    }
}
