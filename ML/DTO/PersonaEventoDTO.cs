using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DTO
{
    public class PersonaEventoDTO
    {
        [Key]
        public int IdPersona { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string Nombre { get; set; }

        [Required, RegularExpression(@"55-[0-9]{8}"), MinLength(11)]
        public string Telefono { get; set; }

        [Required, EmailAddress, RegularExpression(@".+\@(gmail|hotmail|outlook).com"), MaxLength(254)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Empresa { get; set; }
    }
}
