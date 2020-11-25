using PruebaEtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEtechApi.DAO
{
    public class ViajesDAO : IViajesDAO
    {
       
        public Viaje AddViaje(Viaje viaje)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            Viaje model = new Viaje();
            model.Nplazas = viaje.Nplazas;
            model.Origen = viaje.Origen;
            model.Destino = viaje.Destino;
            model.Precio = viaje.Precio;
            
            contextDB.Viajes.Add(model);
            contextDB.SaveChangesAsync();
            return model;
        }

        public void DeleteViaje(Viaje viaje)
        {
            throw new NotImplementedException();
        }

        public Viaje EditViaje(Viaje viaje)
        {
            throw new NotImplementedException();
        }

        public Viaje GetViaje(int Id)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Viajes.SingleOrDefault(x => x.IdViaje == Id);
        }

        public List<Viaje> GetViajes()
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Viajes.ToList();
        }
    }
}
