using System;
using Microsoft.AspNetCore.Mvc;

using App9.Models;
using App9.MobileAppService.Models;

namespace App9.Controllers
{
    [Route("api/[controller]")]
    public class SpreadController : Controller
    {
        private readonly IRepository<Spread> SpreadRepository;

        public SpreadController(IRepository<Spread> spreadRepository)
        {
            SpreadRepository = spreadRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(SpreadRepository.GetAll());
        }

        [HttpGet("{Moeda}/{Empresa}")]
        public Spread GetItem(string moeda, string empresa)
        {
            Spread item = SpreadRepository.Get(moeda, empresa);
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Spread item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                item.Atualizacao = DateTime.Now.AddHours(-3);

                var entity = SpreadRepository.Get(item.EmpresaId, item.Moeda);

                if (entity == null)
                    SpreadRepository.Add(item);
                else
                {
                    if (item.Valor != entity.Valor)
                    {
                        entity.Atualizacao = DateTime.Now.AddHours(-3);
                        entity.Valor = item.Valor;
                        SpreadRepository.Update(entity);
                    }
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