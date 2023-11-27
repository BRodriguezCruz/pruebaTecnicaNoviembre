using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Celular
    {
        public int IdCelular { get; set; }
        public string? Modelo { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaLanzamiento { get; set; }
        public ML.Marca Marca { get; set; }
        public List<object>? Celulares { get; set; }
    }
}
