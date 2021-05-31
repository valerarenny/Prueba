using EtechApi.DAO;
using EtechApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.Controllers
{
    
    [ApiController]
    public class BoletosController : ControllerBase
    {
        private IBoletosDAO _boletosDAO;

        public BoletosController(IBoletosDAO boletos)
        {
            _boletosDAO = boletos;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetBoletos()
        {
            return Ok(_boletosDAO.GetBoletos());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetBoleto(string id)
        {
            var boletos = _boletosDAO.GetBoleto(id);

            if (boletos != null)
            {
                return Ok(_boletosDAO.GetBoleto(id));
            }

            return NotFound($"Viaje con codigo:{id} no ha sido encontrado");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetBoleto(Boleto boleto)
        {
            _boletosDAO.AddBoleto(boleto);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + boleto.IdViajero, boleto);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteBoleto(string id)
        {
            var boleto = _boletosDAO.GetBoleto(id);
            if (boleto != null)
            {
                _boletosDAO.DeleteBoleto(boleto);

                return Ok($"Viaje con codigo:{id} borrado con exito");
            }

            return NotFound($"Viaje con codigo:{id} no ha sido encontrado");

        }
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditBoleto(string id, Boleto boleto)        {
            
            var viajeroExistente = _boletosDAO.GetBoleto(id);

            if (viajeroExistente != null)
            {
                boleto.IdViajero = viajeroExistente.IdViajero;
                Boleto boletoupdated =_boletosDAO.EditBoleto(boleto);
                return Ok(boletoupdated);
            }

            return Ok(boleto);

        }
    }
}
