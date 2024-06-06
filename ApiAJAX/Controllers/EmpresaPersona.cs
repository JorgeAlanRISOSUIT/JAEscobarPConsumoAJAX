using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiAJAX.Controllers
{
    [Route("[controller]/Consume")]
    [ApiController]
    public class EmpresaPersona : ControllerBase
    {

        [HttpGet("Eventos"), Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<ML.DTO.ResultDTO> GetAll()
        {
            ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
            var result = BL.PersonaEvento.GetAll();
            if (result.Item1)
            {
                resultDTO.Success = true;
                resultDTO.Message = result.Item2;
                foreach (ML.PersonaEvento item in result.Item4.Eventos)
                {
                    resultDTO.Objects.Add(item);
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

        [HttpGet("PorEvento/{idPersona}"), Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<ML.DTO.ResultDTO> GetById(int idPersona)
        {
            ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
            var result = BL.PersonaEvento.GetById(idPersona);
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

        [HttpPost("Nuevo"), Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<ML.DTO.ResultDTO> Add(ML.DTO.PersonaEventoDTO evento)
        {
            ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
            if (evento.IdPersona == 0)
            {
                var result = BL.PersonaEvento.Add(new ML.PersonaEvento
                {
                    IdPersona = evento.IdPersona,
                    Nombre = evento.Nombre,
                    Email = evento.Email,
                    Empresa = evento.Empresa,
                    Telefono = evento.Telefono
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
            else
            {
                resultDTO.Message = "No se puede leer el usuario";
                return BadRequest(resultDTO);
            }
        }

        [HttpPut("UltimoMomento"), Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<ML.DTO.ResultDTO> Update([FromBody]ML.DTO.PersonaEventoDTO evento)
        {
            ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
            if (evento.IdPersona > 0)
            {
                var result = BL.PersonaEvento.Update(new ML.PersonaEvento
                {
                    IdPersona = evento.IdPersona,
                    Nombre = evento.Nombre,
                    Email = evento.Email,
                    Empresa = evento.Empresa,
                    Telefono = evento.Telefono
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
            else
            {
                resultDTO.Message = "Esta persona es inexistente";
                return BadRequest();
            }
        }

        [HttpDelete("EventoDeclinado/{idPersona}"), Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<ML.DTO.ResultDTO> Delete(int idPersona)
        {
            ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
            var result = BL.PersonaEvento.Delete(idPersona);
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
