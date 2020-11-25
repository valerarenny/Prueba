using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaEtechApi.DAO;
using PruebaEtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEtechApi.Controllers
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
        public IActionResult GetViaje(int id)
        {
            var viaje = _viajesDAO.GetViaje(id);

            if(viaje != null)
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

           return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/"+ viaje.IdViaje, viaje);
        
        }



        //[HttpGet]
        //public IEnumerable<Viaje> Get()
        //{
        //    using (var contextDB = new ViajesDBRestContext())
        //    return contextDB.Viajes.ToList();

        //}

    }
}
