﻿using System;
using System.Collections.Generic;

namespace DL
{
    public partial class PersonaEvento
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Empresa { get; set; } = null!;
    }
}
