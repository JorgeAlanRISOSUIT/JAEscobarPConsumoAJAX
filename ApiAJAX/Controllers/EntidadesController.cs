using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiAJAX.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EntidadesController : ControllerBase
	{
		[HttpGet("TodoEstado")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult<ML.DTO.ResultDTO> GetAll()
		{
			ML.DTO.ResultDTO resultDTO = new ML.DTO.ResultDTO();
			var result = BL.Entidades.GetAll();
			if (result.Item1)
			{
				resultDTO.Success = true;
				resultDTO.Message = result.Item2;
				foreach(var item in result.Item4.Entidades) 
				{
					resultDTO.Objects.Add(item);
				}
				return Ok(resultDTO);
			}
			else
			{
				resultDTO.Success = false;
				resultDTO.Message = result.Item2;
				resultDTO.Error = result.Item3;
				return BadRequest(resultDTO);
			}
		}
	}
}
