﻿using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class AzureBlob
    {
        private CloudBlobContainer blobContainer;
        CloudStorageAccount storageAccount;

        //1 - user data
        //2 - studio data
        //3 - db-backup
        //3 - temp
        public AzureBlob(int dataRole)
        {
            string dataBlob;
            switch (dataRole)
            {
                case 1:
                    dataBlob = "user-data";
                    break;
                case 2:
                    dataBlob = "studio-data";
                    break;
                case 3:
                    dataBlob = "db-backup";
                    break;
                case 4:
                    dataBlob = "temp";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Data blob code out of range", nameof(dataRole));
            }

            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString"));

            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = cloudBlobClient.GetContainerReference(dataBlob);
            blobContainer.CreateIfNotExists();
        }

        public List<string> GetBlobList()
        {
            // useFlatBlobListing is true to ensure loading all files in
            // virtual blob sub-folders as a plain list
            var list = blobContainer.ListBlobs(useFlatBlobListing: true);
            var listOfFileNames = new List<string>();

            foreach (var blob in list)
            {                
                var blobFileName = blob.Uri.Segments.Last();
                listOfFileNames.Add(blobFileName);
            }

            return listOfFileNames;
        }

        public string UploadFileAPI(HttpPostedFile FileToUpload, string FolderID)
        {
            string AbsoluteUri;
            // Check HttpPostedFileBase is null or not  
            if (FileToUpload == null || FileToUpload.ContentLength == 0)
                return null;
            try
            {
                CloudBlockBlob blockBlob;
                Backbone backbone = new Backbone();
                if (string.IsNullOrWhiteSpace(FolderID))
                {
                    // Create a block blob  
                    blockBlob = blobContainer.GetBlockBlobReference(string.Format("{0}{1}", backbone.Random(7), Path.GetExtension(FileToUpload.FileName)));
                }
                else
                {
                    blockBlob = blobContainer.GetBlockBlobReference(string.Format("{0}/{1}{2}", FolderID, backbone.Random(7), Path.GetExtension(FileToUpload.FileName)));
                }

                // Set the object's content type  
                blockBlob.Properties.ContentType = FileToUpload.ContentType;
                var data = FileToUpload.InputStream.Length;

                // upload to blob  
                blockBlob.UploadFromStream(FileToUpload.InputStream);

                // get file uri  
                AbsoluteUri = blockBlob.Name;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
            return AbsoluteUri;
        }

        public string UploadFile(HttpPostedFileBase FileToUpload, string FolderID, string FileName)
        {
            string AbsoluteUri;
            // Check HttpPostedFileBase is null or not  
            if (FileToUpload == null || FileToUpload.ContentLength == 0)
                return null;
            try
            {
                //string FileName = Path.GetFileName(FileToUpload.FileName);
                CloudBlockBlob blockBlob;
                // Create a block blob  
                blockBlob = blobContainer.GetBlockBlobReference(string.Format("{0}/{1}", FolderID, FileName));
                // Set the object's content type  
                blockBlob.Properties.ContentType = FileToUpload.ContentType;
                var data = FileToUpload.InputStream.Length;

                // upload to blob  
                blockBlob.UploadFromStream(FileToUpload.InputStream);

                // get file uri  
                AbsoluteUri = blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
            return AbsoluteUri;
        }

        public List<string> BlobList(string prefix)
        {
            List<string> _blobList = new List<string>();
            var blobs = blobContainer.ListBlobs(string.Format("{0}/", prefix));

            for (int i = blobs.Count(); i < blobs.Count(); i--)
            {
                if (blobs.ElementAt(i).GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob _blobpage = (CloudBlockBlob)blobs.ElementAt(i);
                    _blobList.Add(_blobpage.Uri.AbsoluteUri.ToString());
                }
            }
            return _blobList;
        }

        public string DeleteBlob(string folder, string AbsoluteUri)
        {
            try
            {
                Uri uriObj = new Uri(AbsoluteUri);
                string BlobName = Path.GetFileName(uriObj.LocalPath);

                // get block blob refarence  
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(string.Format("{0}/{1}", folder, BlobName));

                // delete blob from container      
                blockBlob.Delete();
                return BlobName;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public string MoveBlobFromTemp(int DestinationContainer, string folder, string FileName)
        {
            try
            {
                // get block blob refarence  
                CloudBlockBlob sourceBlob = blobContainer.GetBlockBlobReference(string.Format("{0}", FileName));

                AzureBlob DestinationAzure = new AzureBlob(DestinationContainer);
                CloudBlockBlob destinationBlob = DestinationAzure.blobContainer.GetBlockBlobReference(string.Format("{0}/{1}", folder, FileName));

                destinationBlob.StartCopy(sourceBlob);
                sourceBlob.Delete();

                return FileName;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
    }
}