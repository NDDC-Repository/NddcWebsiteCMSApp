using WebsiteCMSLibrary.Model.HomePage;

namespace WebsiteCMSLibrary.Data.HomePage.Tenders
{
    public interface ITendersData
    {
        void AddTender(MyTenderModel tender);
        List<MyTenderModel> AllTenders();
        void DeleteTender(int id);
        void EditTender(MyTenderModel tender);
        MyTenderModel ViewTenderDetails(int Id);
    }
}