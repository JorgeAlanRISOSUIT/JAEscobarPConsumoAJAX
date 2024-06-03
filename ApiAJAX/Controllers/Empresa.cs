using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAJAX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Empresa : ControllerBase
    {

        [HttpGet("Eventos")]
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
        public ActionResult<DTO.ResultDTO> Add([FromBody] ML.PersonaEvento evento)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
            var result = BL.PersonaEvento.Add(evento);
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
        public ActionResult<DTO.ResultDTO> Update([FromBody] ML.PersonaEvento evento)
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

        [HttpDelete("EventoDeclinado/{:idPersona}")]
        public ActionResult<DTO.ResultDTO> Delete(int idEvento)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
            var result = BL.PersonaEvento.Delete(idEvento);
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
