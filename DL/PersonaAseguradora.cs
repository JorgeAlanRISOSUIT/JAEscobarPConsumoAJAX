using System;
using System.Collections.Generic;

namespace DL
{
    public partial class PersonaAseguradora
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public string? EstadoCivil { get; set; }
        public string Genero { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public int EntidadNacimiento { get; set; }
        public string Curp { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public virtual Estado EntidadNacimientoNavigation { get; set; } = null!;
    }
}
