using GD.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App9.Controllers
{
    [Route("api/[controller]")]
    public class TipoOcorrenciaController : Controller
    {
        [HttpGet("{codigo}")]
        public IActionResult List(int codigo)
        {
            using (var db = new GuardaDigitalContext())
            {
                return Ok(db.TipoOcorrencia.Where(p => p.OcorrenciaId == codigo).OrderBy(p => p.Nome).ToList());
            }
        }
    }
}
