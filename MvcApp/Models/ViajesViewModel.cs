using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class ViajesViewModel
    {
        public string idViaje { get; set; }
        public string nplazas { get; set; }
        public string destino { get; set; }
        public string origen { get; set; }
        public float precio { get; set; }
        public List<BoletoVIewModel> boletos { get; set; }
    }

    public class ViajeroViewModel
    {
        public string IdViajero { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
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
        public IdG IdG { get; set; }
        public ViajesViewModel Viaje { get; set; }
    }

    public class BoletosEditModel
    {
        public IdG IdG { get; set; }
        public BoletoVIewModel Boleto { get; set; }
    }

    public class ViajerosEditModel
    {
        public IdG IdG { get; set; }
        public ViajeroViewModel Viajero { get; set; }
    }
}