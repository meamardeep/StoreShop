using System;
using Azure.Storage;
using System.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace StoreShop.Storage
{
    public class AzureStorageHelper
    {
        private BlobServiceClient _blobServiceClient;
        private BlobContainerClient _containerClient;
        private BlobClient _blobClient;
        string connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";

        public AzureStorageHelper()
        {
         _blobServiceClient = new BlobServiceClient(connectionString);
        }

        //upload blob to a container
        public string CreateBlob(string containerName, string fileName, Stream stream)
        {
            try
            {
                _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                Guid guid = Guid.NewGuid();
                var guidWithExtension = guid.ToString() + Path.GetExtension(fileName);
                
                BlobContentInfo blobContentInfo = _containerClient.UploadBlob(guidWithExtension, stream);
                return guid.ToString();//blobContentInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        
        }
        public string GetBlob(string containerName, string guidWithExtension)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            _blobClient = _containerClient.GetBlobClient(guidWithExtension);
            return _blobClient.Uri.ToString();  
        }
        public BlobContentInfo UpdateBlob(string containerName, string fileName, Stream stream)
        {
            try
            {
                _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                _blobClient = _containerClient.GetBlobClient(fileName);
                BlobContentInfo blobContentInfo = _blobClient.Upload(stream, overwrite: true);
                return blobContentInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
             
        }

        //delete blob from container
        public Azure.Response DeleteBlob(string containerName, string filename)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            Azure.Response response =  _containerClient.DeleteBlob(filename);
            return response;
        }

        //delete container
        public Azure.Response DeleteContainer(string containerName)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            Azure.Response response = _containerClient.Delete();
            return response;
        }

        //list blobs in a container
        public Azure.Pageable<BlobItem> GetBlobList(string containerName)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            Azure.Pageable<BlobItem> blobItems = _containerClient.GetBlobs();
            return blobItems;
        }

        //download a container
    }
}