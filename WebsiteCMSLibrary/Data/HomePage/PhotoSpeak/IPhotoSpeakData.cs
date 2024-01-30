using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.PhotoSpeak
{
    public interface IPhotoSpeakData
    {
        void AddPhotoSpeak(MyPhotoSpeakModel photoSpeak);
        List<MyPhotoSpeakModel> AllPhotos();
        void DeleteUpdate(int id);
        void EditPhotoSpeak(MyPhotoSpeakModel photoSpeak);
    }
}