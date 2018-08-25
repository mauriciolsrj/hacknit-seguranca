using GD.API.Data;
using GD.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GD.API.Controllers
{
    [Route("api/[controller]")]
    public class RegistroOcorrenciaController : Controller
    {
        [HttpGet("{ocorrencia}/{tipoOcorrencia}/{inicio}/{fim}")]
        public IActionResult List(int ocorrencia, int tipoOcorrencia, string inicio, string fim)
        {
            DateTime dataInicio = DateTime.MinValue;
            DateTime dataFim = DateTime.MinValue;

            DateTime.TryParse(inicio, out dataInicio);
            DateTime.TryParse(fim, out dataFim);

            using (var db = new GuardaDigitalContext())
            {
                IQueryable<RelatorioGeoOcorrencias> query = db.RelatorioGeoOcorrencias;

                if (ocorrencia != 0)
                    query = query.Where(p => p.IdOcorrencia == ocorrencia);

                if (tipoOcorrencia != 0)
                    query = query.Where(p => p.IdTipoOcorrencia == tipoOcorrencia);

                if (dataInicio != DateTime.MinValue)
                    query = query.Where(p => p.Inicio >= dataInicio);

                if (dataFim != DateTime.MinValue)
                    query = query.Where(p => p.Fim.HasValue && p.Fim.Value <= dataFim);

                return Ok(query.ToList());
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]RegistroOcorrenciaModel item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                using (var db = new GuardaDigitalContext())
                {
                    db.RegistroOcorrencia.Add(item.Registro);
                    db.SaveChanges();

                    foreach (var matricula in item.Matriculas)
                    {
                        var matriculaTratada = matricula.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ","");
                        var guarda = db.AspNetUsers.FirstOrDefault(p => p.Matricula == matriculaTratada);

                        var relacionamento = new GuardaRo()
                        {
                          GuardaId = guarda.Id,
                          IdRo = item.Registro.Id
                        };

                        db.GuardaRO.Add(relacionamento);
                    }

                    foreach (var envolvido in item.Envolvidos)
                    {
                        envolvido.IdRegistroOcorrencia = item.Registro.Id;
                        db.Envolvido.Add(envolvido);
                    }

                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Error while creating");
            }
            return Ok(item);
        }
    }
}
