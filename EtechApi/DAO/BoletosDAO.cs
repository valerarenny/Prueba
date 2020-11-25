using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
    public class BoletosDAO : IBoletosDAO
    {
        public Boleto AddBoleto(Boleto boleto)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            Viaje model = new Viaje();
            boleto.IdBoleto = Guid.NewGuid().ToString();

            contextDB.Boletos.Add(boleto);
            contextDB.SaveChangesAsync();
            return boleto;
        }

        public void DeleteBoleto(Boleto boleto)
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            contextDB.Boletos.Remove(boleto);
            contextDB.SaveChangesAsync();
        }

        public Boleto EditBoleto(Boleto boleto)
        {
            var boletoExistente = GetBoleto(boleto.IdBoleto);
            boletoExistente.IdViajero = boleto.IdViajero;
            boletoExistente.IdViaje = boleto.IdViaje;        

            return boletoExistente;
        }

        public List<Boleto> GetBoletos()
        {
            ViajesDBRestContext contextDB = new ViajesDBRestContext();
            return contextDB.Boletos.ToList();
        }    

        public Boleto GetBoleto(string id)
        {
        ViajesDBRestContext contextDB = new ViajesDBRestContext();
        return contextDB.Boletos.SingleOrDefault(x => x.IdBoleto == id);
        }

    }
}
