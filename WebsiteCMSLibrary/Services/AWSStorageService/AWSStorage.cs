﻿using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public Task<MyBlobResponseModel> DeleteAsync(string blobFilename)
        {
            throw new NotImplementedException();
        }

        public Task<MyBlobModel> DownloadAsync(string blobFilename)
        {
            throw new NotImplementedException();
        }

        public Task<List<MyBlobModel>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MyBlobResponseModel> UploadAsync(IFormFile file)
        {
            MyBlobResponseModel response = new();
            string myFileName = "News/" + file.FileName;
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
    }
}