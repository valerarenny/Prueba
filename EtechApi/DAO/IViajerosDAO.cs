using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
   public interface IViajerosDAO
    {
        List<Viajero> GetViajeros();

        Viajero GetViajero(Guid id);

        Viajero AddViajero(Viajero viajero);

        void DeleteViajero(Viajero viajero);

        Viajero EditViajero(Viajero viajero);
    }
}
