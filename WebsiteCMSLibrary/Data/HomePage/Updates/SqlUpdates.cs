using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Databases;
using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Updates
{
    public class SqlUpdates : IUpdatesData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlUpdates(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddUpdate(MyUpdateModel update)
        {
            db.SaveData("Insert Into Updates (UpdateType, UpdateCategory, ProjectProgramType, Title, Location, GISCordinates, Description, DescriptionImage, Challenges, ChallengeImage, Impact, ImpactImage, HomeFeatured, AddedBy, DateAdded) values(@UpdateType, @UpdateCategory, @ProjectProgramType, @Title, @Location, @GISCordinates, @Description, @DescriptionImage, @Challenges, @ChallengeImage, @Impact, @ImpactImage, @HomeFeatured, @AddedBy, @DateAdded)", new { update.UpdateType, update.UpdateCategory, update.ProjectProgramType, update.Title, update.Location, update.GISCordinates, update.Description, update.DescriptionImage, update.Challenges, update.ChallengeImage, update.Impact, update.ImpactImage, update.HomeFeatured, update.AddedBy, update.DateAdded }, connectionStringName, false);
        }
        public List<MyUpdateModel> AllUpdates()
        {
            return db.LoadData<MyUpdateModel, dynamic>("select Id, UpdateType, UpdateCategory, ProjectProgramType, Title, Location, GISCordinates, Description, DescriptionImage, Challenges, ChallengeImage, Impact, ImpactImage, HomeFeatured, AddedBy, DateAdded from Updates Order By Id DESC", new { }, connectionStringName, false).ToList();
        }

        public MyUpdateModel UpdatesDetails(int id)
        {
            return db.LoadData<MyUpdateModel, dynamic>("select Id, UpdateType, UpdateCategory, ProjectProgramType, Title, Location, GISCordinates, Description, DescriptionImage, Challenges, ChallengeImage, Impact, ImpactImage, HomeFeatured, AddedBy, DateAdded from Updates Where Id = @Id", new { Id = id }, connectionStringName, false).FirstOrDefault();
        }

        public List<MyUpdateModel> DisplaySlides()
        {
            return db.LoadData<MyUpdateModel, dynamic>("select top 5 Id, Title, DescriptionImage from Updates OrderBy Id DESC", new { }, connectionStringName, false).ToList();
        }
        public MyNewsModel GetImageByUpdateCategory(string updateCategory)
        {
            return db.LoadData<MyNewsModel, dynamic>("select top 1 Id, Subject, DescriptionImage from Updates Where UpdateCategory = @UpdateCategory Order By Id DESC", new { UpdateCategory = updateCategory }, connectionStringName, false).SingleOrDefault();
        }
        public void DeleteUpdate(int id)
        {
            db.SaveData("Delete Updates Where Id = @Id", new { Id = id }, connectionStringName, false);
        }
        public void EditUpdate(MyUpdateModel update)
        {
            db.SaveData("Update Updates Set UpdateType = @UpdateType, UpdateCategory = @UpdateCategory, ProjectProgramType = @ProjectProgramType, Title = @Title, Location = @Location, GISCordinates = @GISCordinates, Description = @Description, DescriptionImage = @DescriptionImage, Challenges = @Challenges, ChallengeImage = @ChallengeImage, Impact = @Impact, ImpactImage = @ImpactImage, HomeFeatured = @HomeFeatured Where Id = @Id", new { UpdateType = update.UpdateType, UpdateCategory = update.UpdateCategory, ProjectProgramType = update.ProjectProgramType, Title = update.Title, Location = update.Location, GISCordinates = update.Location, Description = update.Description, DescriptionImage = update.DescriptionImage, Challenges = update.Challenges, ChallengeImage = update.ChallengeImage, Impact = update.Impact, ImpactImage = update.Impact, HomeFeatured = update.HomeFeatured, Id = update.Id }, connectionStringName, false);
        }
    }
}
