using System.ComponentModel.DataAnnotations;

namespace PáginaAzul.Models
{
    public class PersonaEvento
    {
        public int IdPersona { get; set; }
        [Required, StringLength(5)]
        public string Nombre { get; set; }

        [Required, RegularExpression("[0-9]+")]
        public string Telefono { get; set; }
        [Required, EmailAddress(ErrorMessage = "No es valido el correo")]
        public string Email { get; set; }
        [Required]
        public string Empresa { get; set; }
    }
}
