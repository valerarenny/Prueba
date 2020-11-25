using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EtechWebMVC.Models
{
    public class ViajesViewModel
    {
        public string idViaje { get; set; }
        public string nplazas { get; set; }
        public string destino { get; set; }
        public string origen { get; set; }
        public float precio { get; set; }
        public List<BoletoVIewModel> boletos { get; set;}
    }

    public class VijeroViewModel
    {
        public string IdViajero { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class BoletoVIewModel
    {
        public string IdBoleto { get; set; }
        public Guid IdViajero { get; set; }
        public Guid IdViaje { get; set; }
    }
    public class IdG
    {
        public string IdGuid { get; set; }
    }

    public class ViajesEditModel
    {
        public ViajesViewModel Viaje { get; set;}
        public IdG IdG { get; set; }
    }
}