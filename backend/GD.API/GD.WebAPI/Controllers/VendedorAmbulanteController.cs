using GD.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    public class VendedorAmbulanteController : Controller
    {
        [HttpGet("{inscricao}")]
        public IActionResult Consultar(string inscricao)
        {
            inscricao = inscricao.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");

            var urlQrCode = $"http://api.qrserver.com/v1/create-qr-code/?data={inscricao}&size=695x695";

            using (var db = new GuardaDigitalContext())
            {
                var user = db.AspNetUsers.FirstOrDefault(p => p.Inscricao == inscricao);

                if (user != null)
                {
                    return Ok(new
                    {
                        Nome = user.UserName,
                        Inscricao = user.Inscricao,
                        Latitude = user.Latitude,
                        Longitude = user.Longitude,
                        LocalAtuacao = user.LocalAtuacao,
                        Foto = user.Foto,
                        ValidadeLicenca = user.ValidadeLicenca
                    });
                }

                return NotFound();
            }
        }
    }
}
