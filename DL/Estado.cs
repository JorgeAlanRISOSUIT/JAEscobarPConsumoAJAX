using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Estado
    {
        public Estado()
        {
            PersonaAseguradoras = new HashSet<PersonaAseguradora>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<PersonaAseguradora> PersonaAseguradoras { get; set; }
    }
}
