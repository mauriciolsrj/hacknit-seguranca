using System;
using Microsoft.AspNetCore.Mvc;

using App9.Models;
using App9.MobileAppService.Models;

namespace App9.Controllers
{
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IRepository<Empresa> EmpresaRepository;

        public EmpresaController(IRepository<Empresa> empresaRepository)
        {
            EmpresaRepository = empresaRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(EmpresaRepository.GetAll());
        }

        [HttpGet("{ClientId}")]
        public Empresa GetItem(string clientId)
        {
            Empresa item = EmpresaRepository.Get(clientId);
            return item;
        }   
    }
}