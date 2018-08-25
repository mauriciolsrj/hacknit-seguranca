using System;
using Microsoft.AspNetCore.Mvc;

using App9.Models;
using App9.MobileAppService.Models;
using System.Collections.Generic;

namespace App9.Controllers
{
    [Route("api/[controller]")]
    public class CotacaoController : Controller
    {
        private readonly IRepository<Cotacao> CotacaoRepository;
        private readonly IRepository<Spread> SpreadRepository;
        private readonly AplicarSpreadService aplicarSpreadService;

        public CotacaoController(IRepository<Cotacao> cotacaoRepository, IRepository<Spread> spreadRepository)
        {
            CotacaoRepository = cotacaoRepository;
            SpreadRepository = spreadRepository;
            aplicarSpreadService = new AplicarSpreadService(SpreadRepository);
        }

        [HttpGet("{Empresa}")]
        public IActionResult List(string empresa)
        {
            var cotacoes = CotacaoRepository.GetAll();
            var cotacoesComSpread = new List<Cotacao>();

            foreach (var cotacao in cotacoes)
                cotacoesComSpread.Add(aplicarSpreadService.Aplicar(empresa, cotacao));

            return Ok(cotacoesComSpread);
        }

        [HttpGet("{Moeda}/{Empresa}")]
        public Cotacao GetItem(string moeda, string empresa)
        {
            Cotacao item = CotacaoRepository.Get(moeda);

            return aplicarSpreadService.Aplicar(empresa, item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Cotacao item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                item.Atualizacao = DateTime.Now.AddHours(-3);
                //item.Spread = 0;

                var entity = CotacaoRepository.Get(item.Moeda);

                if (entity == null)
                    CotacaoRepository.Add(item);
                else
                {
                    if (item.Valor != entity.Valor)
                    {
                        entity.Atualizacao = DateTime.Now.AddHours(-3);
                        entity.Valor = item.Valor;
                        CotacaoRepository.Update(entity);
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