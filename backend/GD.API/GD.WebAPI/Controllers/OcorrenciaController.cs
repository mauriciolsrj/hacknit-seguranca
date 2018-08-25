using GD.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App9.Controllers
{
    [Route("api/[controller]")]
    public class OcorrenciaController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            using (var db = new GuardaDigitalContext())
            {
                return Ok(db.Ocorrencia.OrderBy(p => p.Nome).ToList());
            }
        }
    }
}
