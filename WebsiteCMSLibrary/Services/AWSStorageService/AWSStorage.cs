using Amazon.S3;
using Amazon.S3.Transfer;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCMSLibrary.Model.AzureStorage;
using WebsiteCMSLibrary.Services.AzureStorageService;

namespace WebsiteCMSLibrary.Services.AWSStorageService
{
    public class AWSStorage : IAzureStorage
    {
        private readonly string _bucketName;
        private readonly string _accessKey;
        private readonly string _secretAccessKey;
        public AWSStorage(IConfiguration configuration)
        {
            _bucketName = configuration.GetConnectionString("AWSBucketName");
            _accessKey = configuration.GetConnectionString("AWSAccessKeyId");
            _secretAccessKey = configuration.GetConnectionString("AWSSecreteAccessKey");
        }
        
        public Task<MyBlobModel> DownloadAsync(string blobFilename)
        {
            throw new NotImplementedException();
        }

        public Task<List<MyBlobModel>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MyBlobResponseModel> UploadAsync(IFormFile file, string fileName)
        {
            MyBlobResponseModel response = new();
            string myFileName = fileName;
            using (var amazonS3client = new AmazonS3Client(_accessKey, _secretAccessKey, Amazon.RegionEndpoint.EUNorth1))
            {

                using (var memorystream = new MemoryStream())
                {
                    file.CopyTo(memorystream);
                    var request = new TransferUtilityUploadRequest()
                    {
                        InputStream = memorystream,
                        Key = myFileName,
                        BucketName = _bucketName,
                        ContentType = file.ContentType
                    };

                    var transferutility = new TransferUtility(amazonS3client);
                    await transferutility.UploadAsync(request);

                    response.Blob.Uri = request.Key;
                }
            }

            return response;
        }

        public async Task<MyBlobResponseModel> UploadAndResizeImageAsync(IFormFile imageFile, int newWidth, int newHeight, string fileName)
        {
            MyBlobResponseModel response = new();
            string myFileName = fileName;

            // Create a new MemoryStream to store the resized image
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Read the uploaded image into a Bitmap
                using (var uploadedImage = new Bitmap(imageFile.OpenReadStream()))
                {
                    // Create a new Bitmap with the desired dimensions
                    using (var resizedImage = new Bitmap(newWidth, newHeight))
                    {
                        // Create a Graphics object to perform the resizing
                        using (Graphics graphics = Graphics.FromImage(resizedImage))
                        {
                            // Set the interpolation mode to achieve better quality
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                            // Draw the original image onto the resized image with the new dimensions
                            graphics.DrawImage(uploadedImage, 0, 0, newWidth, newHeight);
                        }

                        // Save the resized image to the MemoryStream
                        resizedImage.Save(memoryStream, ImageFormat.Jpeg); // You can adjust the format as needed

                        using (var amazonS3client = new AmazonS3Client(_accessKey, _secretAccessKey, Amazon.RegionEndpoint.EUNorth1))
                        {

                           
                                var request = new TransferUtilityUploadRequest()
                                {
                                    InputStream = memoryStream,
                                    Key = myFileName,
                                    BucketName = _bucketName,
                                    ContentType = imageFile.ContentType
                                };

                                var transferutility = new TransferUtility(amazonS3client);
                                await transferutility.UploadAsync(request);

                                response.Blob.Uri = request.Key;
                            
                        }


                    }
                }

                return response;
            }
        }
        public async Task<MyBlobResponseModel> DeleteAsync(string fileName)
        {
            MyBlobResponseModel response = new();
            string myFileName = fileName;

            using (var amazonS3client = new AmazonS3Client(_accessKey, _secretAccessKey, Amazon.RegionEndpoint.EUNorth1))
            {
                var transferutility = new TransferUtility(amazonS3client);
                await transferutility.S3Client.DeleteObjectAsync(new Amazon.S3.Model.DeleteObjectRequest()
                {
                    BucketName = _bucketName,
                    Key = myFileName

                });

                response.Status = "Success";
            }

            return response;
        }
    }
}
