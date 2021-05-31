using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
    public class BoletosDAO : IBoletosDAO
    {
        private ViajesDAO viajesDao = new ViajesDAO();
        private ViajerosDAO viajerosDao = new ViajerosDAO();
        public Boleto AddBoleto(Boleto boleto)
        {

            ViajesDBRestContext newcontextDB = new ViajesDBRestContext();
            boleto.IdBoleto = Guid.NewGuid().ToString();
            Guid viajesGUID = Guid.Parse(boleto.IdViaje.ToString());

            Guid viajeroGUID = Guid.Parse(boleto.IdViajero.ToString());
            Viaje viaje = viajesDao.GetViaje(viajesGUID);
            Viajero viajero = viajerosDao.GetViajero(viajeroGUID);
            boleto.IdViaje = viaje.IdViaje;
            boleto.IdViajero = viajero.IdViajero;
            newcontextDB.Boletos.Add(boleto);
            newcontextDB.SaveChangesAsync();
            return boleto;
        }

        public void DeleteBoleto(Boleto boleto)
        {
            ViajesDBRestContext newcontextDB = new ViajesDBRestContext();
            newcontextDB.Boletos.Remove(boleto);
            newcontextDB.SaveChangesAsync();
        }

        public Boleto EditBoleto(Boleto boleto)
        {
            ViajesDBRestContext newcontextDB = new ViajesDBRestContext();
            var boletoExistente = GetBoleto(boleto.IdBoleto);
            boletoExistente.IdViajero = boleto.IdViajero;
            boletoExistente.IdViaje = boleto.IdViaje;
            newcontextDB.Update(boletoExistente);
            newcontextDB.SaveChangesAsync();

            return boletoExistente;
        }

        public List<Boleto> GetBoletos()
        {
            ViajesDBRestContext newcontextDB = new ViajesDBRestContext();
            return newcontextDB.Boletos.ToList();
        }    

        public Boleto GetBoleto(string id)
        {
        ViajesDBRestContext newcontextDB = new ViajesDBRestContext();
        return newcontextDB.Boletos.SingleOrDefault(x => x.IdBoleto == id);
        }

    }
}
