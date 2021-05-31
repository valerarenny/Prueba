using System;
using System.Collections.Generic;

#nullable disable

namespace EtechApi.Models
{
    public partial class Viajero
    {
        public Viajero()
        {
            Boletos = new HashSet<Boleto>();
        }

        public Guid IdViajero { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }        

        public virtual ICollection<Boleto> Boletos { get; set; }
    }
}
