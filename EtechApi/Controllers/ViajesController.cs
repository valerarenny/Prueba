using EtechApi.DAO;
using EtechApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.Controllers
{
    [ApiController]
        public class ViajesController : ControllerBase
        {
            private IViajesDAO _viajesDAO;

            public ViajesController(IViajesDAO viajes)
            {
                _viajesDAO = viajes;
            }

            [HttpGet]
            [Route("api/[controller]")]
            public IActionResult GetViajes()
            {
                return Ok(_viajesDAO.GetViajes());
            }

            [HttpGet]
            [Route("api/[controller]/{id}")]
            public IActionResult GetViaje(Guid id)
            {
                var viaje = _viajesDAO.GetViaje(id);

                if (viaje != null)
                {
                    return Ok(_viajesDAO.GetViaje(id));
                }

                return NotFound($"Viaje con codigo:{id} no ha sido encontrado");
            }

            [HttpPost]
            [Route("api/[controller]")]
            public IActionResult GetViaje(Viaje viaje)
            {
                _viajesDAO.AddViaje(viaje);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + viaje.IdViaje, viaje);

            }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteViaje(Guid id)
        {
            var viaje = _viajesDAO.GetViaje(id);
            if (viaje != null)
            {
               _viajesDAO.DeleteViaje(viaje);

                return Ok($"Viaje con codigo:{id} borrado con exito");
            }

            return NotFound($"Viaje con codigo:{id} no ha sido encontrado");          

        }
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditViaje(Guid id, Viaje viaje)
        {
            var viajeExistente = _viajesDAO.GetViaje(id);
            if (viajeExistente != null)
            {
                viaje.IdViaje = viajeExistente.IdViaje;
                _viajesDAO.EditViaje(viaje);
            }

            return Ok(viaje);

        }

        //[HttpGet]
        //public IEnumerable<Viaje> Get()
        //{
        //    using (var contextDB = new ViajesDBRestContext())
        //    return contextDB.Viajes.ToList();

        //}
    }
    }
