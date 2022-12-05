using LumaTasks.Models;
using LumaTasks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LumaTasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAll()
        {
            try
            {
                return Ok(_alunoService.GetAlunos());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById([FromRoute] string id)
        {
            try
            {
                return Ok(_alunoService.GetAlunoById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public ActionResult<Aluno> Register([FromBody] Aluno aluno)
        {
            try
            {
                _alunoService.Register(aluno);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
