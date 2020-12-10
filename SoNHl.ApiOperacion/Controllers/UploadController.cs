using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoNHl.ApiOperacion.Helpers.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IBlobHelper blobHelper;

        public UploadController(IBlobHelper blobHelper)
        {
            this.blobHelper = blobHelper;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile() {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            Uri result = await blobHelper.SubirArchivo("contenedor2", file.OpenReadStream(),
                file.ContentType, file.FileName);

            string cadena = result.AbsoluteUri;

            return Ok(new { path = cadena });
        }
    }
}
