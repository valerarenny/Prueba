using System;
using System.Collections.Generic;

#nullable disable

namespace EtechApi.Models
{
    public partial class Boleto
    {
        public string IdBoleto { get; set; }
        public Guid IdViaje { get; set; }
        public Guid IdViajero { get; set; }

        public virtual Viaje IdViajeNavigation { get; set; }
        public virtual Viajero IdViajeroNavigation { get; set; }
    }
}
