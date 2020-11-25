using System;
using System.Collections.Generic;

#nullable disable

namespace EtechApi.Models
{
    public partial class Viaje
    {
        public Viaje()
        {
            Boletos = new HashSet<Boleto>();
        }

        public Guid IdViaje { get; set; }
        public int? Nplazas { get; set; }
        public string Destino { get; set; }
        public string Origen { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<Boleto> Boletos { get; set; }
    }
}
