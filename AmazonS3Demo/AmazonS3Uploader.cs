using System;
using Amazon.S3;
using Amazon.S3.Model;

namespace AmazonS3Demo
{
    public class AmazonS3Uploader
    {
        private string bucketName = "awss3dailylifehelperapp";
        private string keyName = "jsadlappdev";
        private string filePath = "C:\\Jerry Shen\\test.txt"; 

        public void UploadFile()
        {
            var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast2);

            try
            {
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = filePath,
                    ContentType = "text/plain"
                };

                PutObjectResponse response = client.PutObject(putRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}