using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
    public interface IViajesDAO
    {
        List<Viaje> GetViajes();

        Viaje GetViaje(Guid id);

        Viaje AddViaje(Viaje viaje);

        void DeleteViaje(Viaje viaje);

        Viaje EditViaje(Viaje viaje);
    }
}
