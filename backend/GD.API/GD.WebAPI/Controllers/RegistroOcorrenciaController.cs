﻿using GD.API.Data;
using GD.API.Models;
using GD.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
                IQueryable<RelatorioGeoOcorrencias> query = db.RelatorioGeoOcorrencias.Where(p => p.Latitude.HasValue && p.Latitude != 0 && p.Longitude.HasValue && p.Longitude != 0);

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

            if (item == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }

            var coordenadas = GoogleMapsWrapper.Obter(item.Registro.Endereco);

            ObterCoordenadasGeograficas(item, coordenadas);

            try
            {
                using (var db = new GuardaDigitalContext())
                {
                    RegistrarSolicitacao(item, db);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            return Ok(item);
        }

        private static void RegistrarSolicitacao(RegistroOcorrenciaModel item, GuardaDigitalContext db)
        {
            db.RegistroOcorrencia.Add(item.Registro);
            db.SaveChanges();

            foreach (var matricula in item.Matriculas)
            {
                var matriculaTratada = matricula.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "");
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

        private static void ObterCoordenadasGeograficas(RegistroOcorrenciaModel item, GeocodeResponse coordenadas)
        {
            try
            {
                if (coordenadas.status == "OK")
                {
                    item.Registro.Latitude = coordenadas.result.geometry.location.lat;
                    item.Registro.Latitude = coordenadas.result.geometry.location.lng;
                }
            }
            catch (Exception ex)
            {
                item.Registro.Latitude = null;
                item.Registro.Longitude = null;
            }
        }
    }
}
