using PruebaEtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEtechApi.DAO
{
   public interface IViajesDAO
    {
        List<Viaje> GetViajes();

        Viaje GetViaje(int Id);

        Viaje AddViaje(Viaje viaje);

        void DeleteViaje(Viaje viaje);

        Viaje EditViaje(Viaje viaje);
    }
}
