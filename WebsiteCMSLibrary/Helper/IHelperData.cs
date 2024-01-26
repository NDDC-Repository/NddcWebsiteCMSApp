using Microsoft.AspNetCore.Http;

namespace WebsiteCMSLibrary.Helper
{
    public interface IHelperData
    {
        bool IsImageSizeValid(IFormFile imageFile, int minWidth, int minHeight);
        int RandomNumber(int min, int max);
        string RandomString(int size, bool lowerCase = false);
    }
}