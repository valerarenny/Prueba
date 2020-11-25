using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
    public class ViajesDAO : IViajesDAO
    {
        public Viaje AddViaje(Viaje viaje)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            Viaje model = new Viaje();
            viaje.IdViaje = Guid.NewGuid();
        
            contextDB.Viajes.Add(viaje);
            contextDB.SaveChangesAsync();
            return viaje;
        }

        public void DeleteViaje(Viaje viaje)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            contextDB.Viajes.Remove(viaje);
            contextDB.SaveChangesAsync();
        }

        public Viaje EditViaje(Viaje viaje)
        {
            var viajeExistente = GetViaje(viaje.IdViaje);
            viajeExistente.Destino = viaje.Destino;
            viajeExistente.Nplazas = viaje.Nplazas;
            viajeExistente.Origen = viaje.Origen;
            viajeExistente.Precio = viaje.Precio;

            return viajeExistente;
        }

        public Viaje GetViaje(Guid id)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Viajes.SingleOrDefault(x => x.IdViaje == id);
        }

        public List<Viaje> GetViajes()
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Viajes.ToList();
        }
    }
}
