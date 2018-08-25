using GD.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App9.Controllers
{
    [Route("api/[controller]")]
    public class GuardaController : Controller
    {
        [HttpGet("{matricula}")]
        public IActionResult Consultar(string matricula)
        {
            matricula = matricula.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");

            using (var db = new GuardaDigitalContext())
            {
                var user = db.AspNetUsers.FirstOrDefault(p => p.Matricula == matricula);

                if (user != null)
                {
                    var lotacao = db.Lotacao.FirstOrDefault(p => p.Id == user.LotacaoId);
                    return Ok(new
                    {
                        Nome = user.UserName,
                        Matricula = user.Matricula,
                        Lotacao = lotacao != null ? lotacao.Nome : ""
                    });
                }

                return NotFound();
            }
        }
    }
}
