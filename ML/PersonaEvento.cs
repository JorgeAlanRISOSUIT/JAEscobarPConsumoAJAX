using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class PersonaEvento
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public List<PersonaEvento> Eventos { get; set; }
    }
}
