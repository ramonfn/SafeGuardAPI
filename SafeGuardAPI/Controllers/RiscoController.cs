using Microsoft.AspNetCore.Mvc;
using SafeGuardAPI.Models;
using SafeGuardAPI.Services;
using SafeGuardAPI.Exceptions;

namespace SafeGuardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiscoController : ControllerBase
    {
        private readonly RiscoService _riscoService;

        public RiscoController(RiscoService riscoService)
        {
            _riscoService = riscoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Risco>>> Get()
        {
            var riscos = await _riscoService.GetAllRiscosAsync();
            return Ok(riscos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Risco>> Get(int id)
        {
            try
            {
                var risco = await _riscoService.GetRiscoByIdAsync(id);
                if (risco == null) return NotFound();
                return Ok(risco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Risco risco)
        {
            try
            {
                await _riscoService.UpdateRiscoAsync(id, risco);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Risco risco)
        {
            try
            {
                var createdRisco = await _riscoService.AddRiscoAsync(risco);
                return CreatedAtAction(nameof(Get), new { id = createdRisco.IdRisco });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _riscoService.DeleteRiscoAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return BadRequest(new { StatusCode = 404, Message = ex.Message });
            }
        }

        [HttpGet("estacao/{estacaoId}")]
        public async Task<ActionResult<IEnumerable<Risco>>> GetByEstacaoId(int estacaoId)
        {
            var riscos = await _riscoService.GetRiscoByEstacaoIdAsync(estacaoId);
            return Ok(riscos);
        }

        [HttpGet("filtro/{estacaoId}/{nivel}")]
        public async Task<ActionResult<IEnumerable<Risco>>> Filtro(int estacaoId, int nivel)
        {
            var riscos = await _riscoService.FiltroRiscoAsync(estacaoId, nivel);
            return Ok(riscos);
        }
    }
}
