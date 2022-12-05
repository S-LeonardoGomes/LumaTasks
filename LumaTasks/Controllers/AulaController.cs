using LumaTasks.Models;
using LumaTasks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LumaTasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AulaController : ControllerBase
    {
        private readonly IAulaService _aulaService;

        public AulaController(IAulaService aulaService)
        {
            _aulaService = aulaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aula>> GetAulas()
        {
            try
            {
                return Ok(_aulaService.GetAulas());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Aula> GetAulaById([FromRoute] string id)
        {
            try
            {
                return Ok(_aulaService.GetAulaById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("AgendarAula")]
        public ActionResult<Aula> ScheduleEvent([FromBody] Aula aula)
        {
            try
            {
                _aulaService.ScheduleEvent(aula);
                return Ok(aula);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("EditarAgendamento")]
        public ActionResult UpdateEvent([FromBody] Aula aula)
        {
            try
            {
                _aulaService.UpdateEvent(aula);
                return Ok(aula);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
