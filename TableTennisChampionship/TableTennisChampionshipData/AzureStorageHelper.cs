

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
    /// <summary>
    /// Създава storage account, blob client и profilepicture container.
    /// </summary>
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
            if ( this.container.CreateIfNotExists())
            {
                // Enable public access on the newly created "images" container
                this.container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess =
                        BlobContainerPublicAccessType.Blob
                });
            }
        }
        /// <summary>
        /// Създава blob, като копира файл в MemoryStream и се подава като байт масив на Upload метода.
        /// </summary>
        /// <param name="fileName">име на файла, което автоматично се сетва на име на блоба</param>
        /// <param name="postedFile">Файлът като тип HttpPostedFileBase</param>
        /// <returns>Дали е успечно качванто</returns>
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
                blockBlob.UploadFromByteArrayAsync(data, 0, data.Count<byte>(), null, null, null);
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
        /// <summary>
        /// Връща пълния Url на блоб с дадено име
        /// </summary>
        /// <param name="fileName">Име на блоба</param>
        /// <returns>String - URL</returns>
        public string FullBlobUrl( string fileName )
        {
            CloudBlockBlob blockBlob = this.container.GetBlockBlobReference(fileName);
            return  String.Format("http://{0}{1}", blockBlob.Uri.DnsSafeHost, blockBlob.Uri.AbsolutePath);
        }

        public bool DeleteBlob(string fileName)
        { 
            bool isSuccess=true;
            try
            {
                CloudBlockBlob blockBlob = this.container.GetBlockBlobReference(fileName);
                blockBlob.Delete();
            }
            catch(Exception ex)
            { 
                
            }
           return isSuccess;
        }
        
    }
}
