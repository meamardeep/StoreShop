using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using StoreShop.Helper;

namespace StoreShop.Storage
{
    public class AzureQueueStorageHelper
    {
        //QueueClient _queueClient;
        //QueueServiceClient _queueServiceClient;
        string connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";

        public AzureQueueStorageHelper()
        {
            //_queueServiceClient = new QueueServiceClient(connectionString);
        }

        public void AddMessageToQueue(string queueName, string messageText)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            queueClient.CreateIfNotExists();
            if (queueClient.Exists())
            {
                queueClient.SendMessage(DataConverter.ConvertToBase64(messageText));
            }
        }
       
    }
}
