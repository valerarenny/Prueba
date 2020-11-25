using EtechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtechApi.DAO
{
    public interface IBoletosDAO
    {
        List<Boleto> GetBoletos();

        Boleto GetBoleto(string id);

        Boleto AddBoleto(Boleto boleto);

        void DeleteBoleto(Boleto boleto);

        Boleto EditBoleto(Boleto boleto);
    }
}
