using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAJAX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Persona : ControllerBase
    {

        [HttpGet("Aseguradora")]
        public ActionResult<DTO.ResultDTO> GetAll()
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
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
        public ActionResult<DTO.ResultDTO> GetById(int idPersona)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
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
        public ActionResult<DTO.ResultDTO> Add([FromBody] ML.PersonaAseguradora aseguradora)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
            var result = BL.PersonaAseguradora.Add(aseguradora);
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
        public ActionResult<DTO.ResultDTO> Put([FromBody] ML.PersonaAseguradora aseguradora)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
            var result = BL.PersonaAseguradora.Update(aseguradora);
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
        public ActionResult<DTO.ResultDTO> Delete(int idPersona)
        {
            DTO.ResultDTO resultDTO = new DTO.ResultDTO();
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
