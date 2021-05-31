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
    public class ViajerosController : ControllerBase
    {
        private IViajerosDAO _viajerosDAO;

        public ViajerosController(IViajerosDAO viajeros)
        {
            _viajerosDAO = viajeros;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetViajeros()
        {
            return Ok(_viajerosDAO.GetViajeros());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetViajero(Guid id)
        {
            var viajero = _viajerosDAO.GetViajero(id);

            if (viajero != null)
            {
                return Ok(_viajerosDAO.GetViajero(id));
            }

            return NotFound($"Viajero con codigo:{id} no ha sido encontrado");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetViajero(Viajero viajero)
        {
            _viajerosDAO.AddViajero(viajero);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + viajero.IdViajero, viajero);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteViajero(Guid id)
        {
            var viajero = _viajerosDAO.GetViajero(id);
            if (viajero != null)
            {
                _viajerosDAO.DeleteViajero(viajero);

                return Ok($"Viajero con codigo:{id} borrado con exito");
            }

            return NotFound($"Viajero con codigo:{id} no ha sido encontrado");

        }
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditViajero(Guid id, Viajero viajero)
        {
            var viajeroExistente = _viajerosDAO.GetViajero(id);
            if (viajeroExistente != null)
            {
                viajero.IdViajero = viajeroExistente.IdViajero;
                _viajerosDAO.EditViajero(viajero);
            }

            return Ok(viajero);

        }
    }
}
