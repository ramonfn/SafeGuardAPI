using Microsoft.AspNetCore.Mvc;
using SafeGuardAPI.Models;
using SafeGuardAPI.Services;
using SafeGuardAPI.Exceptions;

namespace SafeGuardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeituraController : ControllerBase
    {
        private readonly LeituraService _leituraService;

        public LeituraController(LeituraService leituraService)
        {
            _leituraService = leituraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leitura>>> Get()
        {
            var leituras = await _leituraService.GetAllLeiturasAsync();
            return Ok(leituras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leitura>> Get(int id)
        {
            try
            {
                var leitura = await _leituraService.GetLeituraByIdAsync(id);
                if (leitura == null) return NotFound();
                return Ok(leitura);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Leitura leitura)
        {
            try
            {
                await _leituraService.UpdateLeituraAsync(id, leitura);
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
        public async Task<ActionResult> Post(Leitura leitura)
        {
            try
            {
                var createdLeitura = await _leituraService.AddLeituraAsync(leitura);
                return CreatedAtAction(nameof(Get), new { id = createdLeitura.IdLeitura });
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
                await _leituraService.DeleteLeituraAsync(id);
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

        [HttpGet("sensor/{sensorId}")]
        public async Task<ActionResult<IEnumerable<Leitura>>> GetBySensorId(int sensorId)
        {
            var leituras = await _leituraService.GetLeituraBySensorIdAsync(sensorId);
            return Ok(leituras);
        }

        [HttpGet("filtro/{sensorId}/{dataHora}")]
        public async Task<ActionResult<IEnumerable<Leitura>>> Filtro(int sensorId, DateTime dataHora)
        {
            var leituras = await _leituraService.FiltroLeituraAsync(sensorId, dataHora);
            return Ok(leituras);
        }
    }
}
