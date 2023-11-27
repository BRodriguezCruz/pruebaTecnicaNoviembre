using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Celular
    {
        public int IdCelular { get; set; }
        public string? Modelo { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaLanzamiento { get; set; }
        public int? IdMarca { get; set; }

        public virtual Marca? IdMarcaNavigation { get; set; }

        //PROPIEDAD PARA EL ALIAS
        public string NombreMarca { get; set; }
    }
}
