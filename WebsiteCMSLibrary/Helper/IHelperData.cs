namespace WebsiteCMSLibrary.Helper
{
    public interface IHelperData
    {
        int RandomNumber(int min, int max);
        string RandomString(int size, bool lowerCase = false);
    }
}