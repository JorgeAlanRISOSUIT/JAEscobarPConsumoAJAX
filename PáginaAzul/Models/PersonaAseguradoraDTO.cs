using ML;
using System.ComponentModel.DataAnnotations;

namespace PáginaAzul.Pages
{
    public class PersonaAseguradoraDTO
    {
        public int IdPersona { get; set; }
        [Required]
        [StringLength(5)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(10)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(10)]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string EstadoCivil { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public Entidad Entidad { get; set; }
        [Required]
        [StringLength(18)]
        public string CURP { get; set; }
        [Required]
        [StringLength(18)]
        public string RFC { get; set; }
        [Required]
        [RegularExpression("[0-9]+")]
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
    }
}
