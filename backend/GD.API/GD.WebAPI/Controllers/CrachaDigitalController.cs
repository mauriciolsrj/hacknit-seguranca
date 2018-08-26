using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;   

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    public class CrachaDigitalController : Controller
    {
        [HttpPost]
        public IActionResult QRCode(IList<IFormFile> files)
        {
            var msg = "";

            foreach (IFormFile source in files)
            {
                try
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                    //var name = Guid.NewGuid().ToString().Replace("-", "");
                    //var extensao = Path.GetExtension(filename);
                    //filename = Path.Combine(name, extensao);

                    filename = this.EnsureCorrectFilename(filename);
                    var tempFileName = filename;

                    msg = filename;
                    using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                        source.CopyTo(output);
                                                
                    var urlQRCode = string.Format("http://api.qrserver.com/v1/read-qr-code/?fileurl=http://api.guarda.digital/uploads/{0}", tempFileName);

                    using (var client = new WebClient())
                    {
                        var dados = client.DownloadString(urlQRCode);

                        return Ok(dados);
                    } 
                }
                catch (System.Exception ex)
                {
                    msg = ex.Message;
                }
            }

            return Ok(msg);
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return Path.Combine(@"D:\home\site\wwwroot\", @"uploads\", filename);
        }
    }
}
