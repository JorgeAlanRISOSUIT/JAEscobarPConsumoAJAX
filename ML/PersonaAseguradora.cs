using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class PersonaAseguradora
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Entidad Entidad { get; set; } = null!;
        public string CURP { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public List<PersonaAseguradora> aseguradoras { get; set; }
    }
}
