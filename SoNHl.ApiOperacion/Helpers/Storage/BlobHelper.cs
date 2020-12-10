using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Helpers.Storage
{
    public class BlobHelper : IBlobHelper
    {
        private readonly BlobServiceClient blobService;

        public BlobHelper(BlobServiceClient blobService)
        {
            this.blobService = blobService;
        }

        public async Task<Uri> SubirArchivo(string blobContainerName, Stream contenido, string contentType, string fileName)
        {
            BlobContainerClient containerClient = RecuperaContenedor(blobContainerName);
            var blobCliente = containerClient.GetBlobClient(fileName);

            await blobCliente.UploadAsync(contenido, new BlobHttpHeaders { ContentType = contentType });

            return blobCliente.Uri;
        }

        private BlobContainerClient RecuperaContenedor(string blobContainerName)
        {
            var containerClient = blobService.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;


        }
    }
}
