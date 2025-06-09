using Microsoft.AspNetCore.Mvc;
using SafeGuardAPI.Models;
using SafeGuardAPI.Services;
using SafeGuardAPI.Exceptions;

namespace SafeGuardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SensorService _sensorService;

        public SensorController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> Get()
        {
            var sensores = await _sensorService.GetAllSensorsAsync();
            return Ok(sensores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> Get(int id)
        {
            try
            {
                var sensor = await _sensorService.GetSensorByIdAsync(id);
                if (sensor == null) return NotFound();
                return Ok(sensor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Sensor sensor)
        {
            try
            {
                await _sensorService.UpdateSensorAsync(id, sensor);
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
        public async Task<ActionResult> Post(Sensor sensor)
        {
            try
            {
                var createdSensor = await _sensorService.AddSensorAsync(sensor);
                return CreatedAtAction(nameof(Get), new { id = createdSensor.IdSensor });
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
                await _sensorService.DeleteSensorAsync(id);
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
        public async Task<ActionResult<IEnumerable<Sensor>>> GetByEstacaoId(int estacaoId)
        {
            var sensores = await _sensorService.GetSensorByEstacaoIdAsync(estacaoId);
            return Ok(sensores);
        }

        [HttpGet("filtro/{estacaoId}/{tipoSensor}")]
        public async Task<ActionResult<IEnumerable<Sensor>>> Filtro(int estacaoId, string tipoSensor)
        {
            var sensores = await _sensorService.FiltroSensorAsync(estacaoId, tipoSensor);
            return Ok(sensores);
        }
    }
}
