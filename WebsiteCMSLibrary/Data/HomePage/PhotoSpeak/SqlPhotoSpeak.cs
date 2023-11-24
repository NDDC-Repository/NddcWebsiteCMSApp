using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.PhotoSpeak
{
    public class SqlPhotoSpeak : IPhotoSpeakData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlPhotoSpeak(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddPhotoSpeak(MyPhotoSpeakModel photoSpeak)
        {
            db.SaveData("Insert Into PhotoSpeak (Title, Location, ImageUrl, DateAdded, AddedBy) values(@Title, @Location, @ImageUrl, @DateAdded, @AddedBy)", new { photoSpeak.Title, photoSpeak.Location, photoSpeak.ImageUrl, photoSpeak.DateAdded, photoSpeak.AddedBy }, connectionStringName, false);
        }
        public List<MyPhotoSpeakModel> AllPhotos()
        {
            return db.LoadData<MyPhotoSpeakModel, dynamic>("Select Title, Location, ImageUrl, DateAdded From PhotoSpeak Order By Id DESC", new { }, connectionStringName, false).ToList();
        }

        public void DeleteUpdate(int id)
        {
            db.SaveData("Delete PhotoSpeak Where Id = @Id", new { Id = id }, connectionStringName, false);
        }
        public void EditUpdate(MyPhotoSpeakModel photoSpeak)
        {
            db.SaveData("Update Updates Set UpdateType = @UpdateType, UpdateCategory = @UpdateCategory, ProjectProgramType = @ProjectProgramType, Title = @Title, Location = @Location, GISCordinates = @GISCordinates, Description = @Description, DescriptionImage = @DescriptionImage, Challenges = @Challenges, ChallengeImage = @ChallengeImage, Impact = @Impact, ImpactImage = @ImpactImage, HomeFeatured = @HomeFeatured Where Id = @Id", new { photoSpeak }, connectionStringName, false);
        }
    }
}
