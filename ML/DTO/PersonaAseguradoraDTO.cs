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
		[RegularExpression(@"[a-zA-Z]+\s*")]
		public string Nombre { get; set; }
		[Required]
		[StringLength(30, MinimumLength = 7)]
		[RegularExpression(@"[a-zA-Z]+\s*")]
		public string ApellidoPaterno { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 5)]
		[RegularExpression(@"[a-zA-Z]+\s*")]
		public string ApellidoMaterno { get; set; }
		[Required]
		public string EstadoCivil { get; set; }
		[Required, MaxLength(1)]
		public string Genero { get; set; }
		[Required]
		[DisplayFormat(DataFormatString = "YYYY/MM/DD")]
		public DateTime FechaNacimiento { get; set; }
		public Entidad Entidad { get; set; } = null!;
		[Required]
		[StringLength(18)]
		public string CURP { get; set; }

		[Required]
		public string RFC { get; set; }

		[Required]
		[RegularExpression(@"[5][5]\-[0-9]{8}")]
		public string Telefono { get; set; }

		[Required]
		[RegularExpression(@".+\@(gmail|hotmail|outlook)\.[com]")]
		[EmailAddress]
		public string Correo { get; set; }
	}
}
