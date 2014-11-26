

namespace TableTennisChampionshipData
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    public  class AzureStorageHelper
    {
        private  CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("tennisprofilepictures"));

        // Create the blob client.
        private CloudBlobClient blobClient; //storageAccount.CreateCloudBlobClient();

        //  // Retrieve a reference to a container. 
        private CloudBlobContainer container;
        public AzureStorageHelper() 
        {
            this.blobClient = this.storageAccount.CreateCloudBlobClient();
            this.container = this.blobClient.GetContainerReference("profilepictures");
            this.container.CreateIfNotExists();

        }

        public  bool CreateBlob(string fileName,System.Web.HttpPostedFileBase postedFile) 
        {
            bool isSuccess=true;
            CloudBlockBlob blockBlob = this.container.GetBlockBlobReference(fileName);
            System.IO.MemoryStream target = new System.IO.MemoryStream();
            try
            {   
                postedFile.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                // blockBlob.UploadFromStream(target);
                blockBlob.UploadFromByteArray(data, 0, data.Count<byte>(), null, null, null);
            }
            catch (Exception ex)
            {
                isSuccess = false;

            }
            finally
            {
                target.Dispose();
            }
            return isSuccess;
        }
       
        
    }
}
