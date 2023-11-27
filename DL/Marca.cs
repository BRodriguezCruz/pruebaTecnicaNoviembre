using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Marca
    {
        public Marca()
        {
            Celulars = new HashSet<Celular>();
        }

        public int IdMarca { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Celular> Celulars { get; set; }
    }
}
