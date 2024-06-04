using System.ComponentModel.DataAnnotations;

namespace PáginaAzul.Models
{
    public class PersonaEventoDTO
    {
        public int IdPersona { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"[a-zA-Z]+(\s*)?")]
        public string Nombre { get; set; }

        [Required]
        [RegularExpression("[55]([-])?([0-9]+)", ErrorMessage = "Debe ser así 55-5555555 con diez digitos")]
        [StringLength(10, ErrorMessage = "Debe por lo menos tener 10 digitos")]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "No es valido el correo")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Empresa { get; set; }
    }
}
