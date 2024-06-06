using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiAJAX.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AseguradoraPersona : ControllerBase
	{

		[HttpGet("Aseguradora")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult<ML.DTO.ResultDTO> GetAll()
		{
			ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
			var result = BL.PersonaAseguradora.GetAll();
			if (result.Item1)
			{
				resultDTO.Success = true;
				resultDTO.Message = result.Item2;
				foreach (ML.PersonaAseguradora asegurado in result.Item4.Aseguradoras)
				{
					resultDTO.Objects.Add(asegurado);
				}
				return Ok(resultDTO);
			}
			else
			{
				resultDTO.Error = result.Item3;
				resultDTO.Message = result.Item2;
				return BadRequest(resultDTO);
			}
		}

		[HttpGet("ConsultaAsegurador")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult<ML.DTO.ResultDTO> GetById(int idPersona)
		{
			ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
			var result = BL.PersonaAseguradora.GetById(idPersona);
			if (result.Item1)
			{
				resultDTO.Success = true;
				resultDTO.Message = result.Item2;
				resultDTO.Object = result.Item4;
				return Ok(resultDTO);
			}
			else
			{
				resultDTO.Error = result.Item3;
				resultDTO.Message = result.Item2;
				return BadRequest(resultDTO);
			}
		}

		[HttpPost("NuevoRegistro")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult<ML.DTO.ResultDTO> Add([FromBody] ML.DTO.PersonaAseguradoraDTO aseguradora)
		{
			ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
			if (!ModelState.IsValid)
			{
				return BadRequest(resultDTO);
			}
			var result = BL.PersonaAseguradora.Add(new ML.PersonaAseguradora
			{
				IdPersona = aseguradora.IdPersona,
				Nombre = aseguradora.Nombre,
				ApellidoPaterno = aseguradora.ApellidoPaterno,
				ApellidoMaterno = aseguradora.ApellidoMaterno,
				Entidad = new ML.Entidad
				{
					IdEntidad = aseguradora.Entidad.IdEntidad,
					Nombre = aseguradora.Entidad.Nombre,
				},
				Correo = aseguradora.Correo,
				CURP = aseguradora.CURP,
				EstadoCivil = aseguradora.EstadoCivil,
				FechaNacimiento = aseguradora.FechaNacimiento,
				Genero = aseguradora.Genero,
				RFC = aseguradora.RFC,
				Telefono = aseguradora.Telefono,
				Aseguradoras = new List<ML.PersonaAseguradora>()
			});
			if (result.Item1)
			{
				resultDTO.Success = true;
				resultDTO.Message = result.Item2;
				return Ok(resultDTO);
			}
			else
			{
				resultDTO.Error = result.Item3;
				resultDTO.Message = result.Item2;
				return BadRequest(resultDTO);
			}
		}

		[HttpPut("Cambios")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult<ML.DTO.ResultDTO> Put([FromBody] ML.DTO.PersonaAseguradoraDTO aseguradora)
		{
			ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var result = BL.PersonaAseguradora.Update(new ML.PersonaAseguradora
			{
				IdPersona = aseguradora.IdPersona,
				Nombre = aseguradora.Nombre,
				ApellidoPaterno = aseguradora.ApellidoPaterno,
				ApellidoMaterno = aseguradora.ApellidoMaterno,
				Entidad = new ML.Entidad
				{
					IdEntidad = aseguradora.Entidad.IdEntidad,
					Nombre = aseguradora.Entidad.Nombre,
				},
				Correo = aseguradora.Correo,
				CURP = aseguradora.CURP,
				EstadoCivil = aseguradora.EstadoCivil,
				FechaNacimiento = aseguradora.FechaNacimiento,
				Genero = aseguradora.Genero,
				RFC = aseguradora.RFC,
				Telefono = aseguradora.Telefono,
				Aseguradoras = new List<ML.PersonaAseguradora>()
			});
			if (result.Item1)
			{
				resultDTO.Success = true;
				resultDTO.Message = result.Item2;
				return Ok(resultDTO);
			}
			else
			{
				resultDTO.Error = result.Item3;
				resultDTO.Message = result.Item2;
				return BadRequest(resultDTO);
			}
		}

		[HttpDelete("DeclinarAsegurador/{idPersona}")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult<ML.DTO.ResultDTO> Delete(int idPersona)
		{
			ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
			var result = BL.PersonaAseguradora.Delete(idPersona);
			if (result.Item1)
			{
				resultDTO.Success = true;
				resultDTO.Message = result.Item2;
				return Ok(resultDTO);
			}
			else
			{
				resultDTO.Error = result.Item3;
				resultDTO.Message = result.Item2;
				return BadRequest(resultDTO);
			}
		}
	}
}
