using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
    public class ViajerosDAO : IViajerosDAO
    {
        public Viajero AddViajero(Viajero viajero)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            Viajero model = new Viajero();
            viajero.IdViajero = Guid.NewGuid();

            contextDB.Viajeros.Add(viajero);
            contextDB.SaveChangesAsync();
            return viajero;
        }

        public void DeleteViajero(Viajero viajero)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            contextDB.Viajeros.Remove(viajero);
            contextDB.SaveChangesAsync();
        }

        public Viajero EditViajero(Viajero viajero)
        {
            var viajeroExistente = GetViajero(viajero.IdViajero);
            viajeroExistente.Nombre = viajero.Nombre;
            viajeroExistente.Apellido = viajero.Apellido;
            viajeroExistente.Cedula = viajero.Cedula;
            viajeroExistente.Telefono = viajero.Telefono;

            return viajeroExistente;
        }

        public Viajero GetViajero(Guid id)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Viajeros.SingleOrDefault(x => x.IdViajero == id);
        }

        public List<Viajero> GetViajeros()
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Viajeros.ToList();
        }
    }
}
