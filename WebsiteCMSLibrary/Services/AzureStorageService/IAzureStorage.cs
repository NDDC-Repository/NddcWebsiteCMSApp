using Microsoft.AspNetCore.Http;
using WebsiteCMSLibrary.Model.AzureStorage;

namespace WebsiteCMSLibrary.Services.AzureStorageService
{
    public interface IAzureStorage
    {
        Task<MyBlobResponseModel> DeleteAsync(string fileName);
        Task<MyBlobModel> DownloadAsync(string blobFilename);
        Task<List<MyBlobModel>> ListAsync();
        Task<MyBlobResponseModel> UploadAndResizeImageAsync(IFormFile imageFile, int newWidth, int newHeight, string fileName);
        Task<MyBlobResponseModel> UploadAsync(IFormFile blob, string fileName);
    }
}