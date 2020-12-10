using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Helpers.Storage
{
    public interface IBlobHelper
    {
        Task<Uri> SubirArchivo(string blobContainerName, Stream contenido, 
                string contentType, string fileName);
    }
}
