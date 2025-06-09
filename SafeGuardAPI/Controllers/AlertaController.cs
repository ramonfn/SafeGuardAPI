using Microsoft.AspNetCore.Mvc;
using SafeGuardAPI.Models;
using SafeGuardAPI.Services;
using SafeGuardAPI.Exceptions;

namespace SafeGuardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaService _alertaService;

        public AlertaController(AlertaService alertaService)
        {
            _alertaService = alertaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> Get()
        {
            var alertas = await _alertaService.GetAllAlertasAsync();
            return Ok(alertas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> Get(int id)
        {
            try
            {
                var alerta = await _alertaService.GetAlertaByIdAsync(id);
                if (alerta == null) return NotFound();
                return Ok(alerta);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Alerta alerta)
        {
            try
            {
                await _alertaService.UpdateAlertaAsync(id, alerta);
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
        public async Task<ActionResult> Post(Alerta alerta)
        {
            try
            {
                var createdAlerta = await _alertaService.AddAlertaAsync(alerta);
                return CreatedAtAction(nameof(Get), new { id = createdAlerta.IdAlerta });
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
                await _alertaService.DeleteAlertaAsync(id);
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
        public async Task<ActionResult<IEnumerable<Alerta>>> GetBySensorId(int sensorId)
        {
            var alertas = await _alertaService.GetAlertaBySensorIdAsync(sensorId);
            return Ok(alertas);
        }

        [HttpGet("filtro/{sensorId}/{dataHora}")]
        public async Task<ActionResult<IEnumerable<Alerta>>> Filtro(int sensorId, DateTime dataHora)
        {
            var alertas = await _alertaService.FiltroAlertaAsync(sensorId, dataHora);
            return Ok(alertas);
        }
    }
}
