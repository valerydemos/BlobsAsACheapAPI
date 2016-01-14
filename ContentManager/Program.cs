using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ContentManager
{
    class Program
    {
        static void Main(string[] args)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=vjdemostorage;AccountKey=vwEq8bSfqCrz7usnTZ7UUpWe8f+PZRxk##### YOU WISH! #####ZOjVSZ8N9VBHv+xtztaYcF1P4xHwg==;");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("cheapapi");
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions
            {
                PublicAccess =
            BlobContainerPublicAccessType.Blob
            });


            CloudBlockBlob blockBlob = container.GetBlockBlobReference("data.json");

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@"c:\Files\data.json"))
            {
                blockBlob.UploadFromStream(fileStream);
            }


            Console.WriteLine("Press ESC to stop");
            do
            {

                Console.WriteLine("Update the file and press a key.");
                

                using (var fileStream = System.IO.File.OpenRead(@"c:\Files\data.json"))
                {
                    blockBlob.UploadFromStream(fileStream);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
