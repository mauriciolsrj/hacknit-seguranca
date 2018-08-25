using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    public class CrachaDigitalController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> QRCode(IList<IFormFile> files)
        {
            foreach (IFormFile source in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                filename = this.EnsureCorrectFilename(filename);

                using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                    await source.CopyToAsync(output);
            }

            return this.View();
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return Path.Combine(@"D:\home\site\wwwroot\",@"uploads\",filename);
        }
    }
}
