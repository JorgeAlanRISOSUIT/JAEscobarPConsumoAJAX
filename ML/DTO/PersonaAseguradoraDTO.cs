using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DTO
{
	public class PersonaAseguradoraDTO
	{
		public int IdPersona { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 5)]
		[RegularExpression("[^0-9]+")]
		public string Nombre { get; set; }
		[Required]
		[StringLength(30, MinimumLength = 7)]
		[RegularExpression("[a-zA-Z]+\\s*")]
		public string ApellidoPaterno { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 5)]
		[RegularExpression("[a-zA-Z]+\\s*")]
		public string ApellidoMaterno { get; set; }
		[Required]
		public string EstadoCivil { get; set; }
		[Required, MaxLength(1), RegularExpression("[M|F]")]
		public string Genero { get; set; }
		[Required]
		public DateTime FechaNacimiento { get; set; }
		[Required]
		public EntidadDTO Entidad { get; set; }

		[Required, MaxLength(18), MinLength(18)]
		public string CURP { get; set; }

		[Required]
		public string RFC { get; set; }

		[Required, MinLength(10)]
		[RegularExpression("[0-9]{10}")]
		public string Telefono { get; set; }

		[Required]
		[RegularExpression(".+\\@(gmail|hotmail|outlook)\\.com")]
		[EmailAddress]
		public string Correo { get; set; }
	}
}
