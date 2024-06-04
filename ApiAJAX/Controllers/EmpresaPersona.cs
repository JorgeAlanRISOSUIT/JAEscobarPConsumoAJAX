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

        [HttpGet("Eventos")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<DTO.ResultDTO> GetAll()
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
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

        [HttpGet("PorEvento/{idPersona}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<DTO.ResultDTO> GetById(int idPersona)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
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

        [HttpPost("Nuevo")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<DTO.ResultDTO> Add(ML.DTO.PersonaEventoDTO evento)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
            var result = BL.PersonaEvento.Add(new ML.PersonaEvento { 
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

        [HttpPut("UltimoMomento")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<DTO.ResultDTO> Update(ML.PersonaEvento evento)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
            var result = BL.PersonaEvento.Update(evento);
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

        [HttpDelete("EventoDeclinado/{idPersona}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<DTO.ResultDTO> Delete(int idPersona)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
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
