using Microsoft.AspNetCore.Mvc;
using SafeGuardAPI.Models;
using SafeGuardAPI.Services;
using SafeGuardAPI.Exceptions;

namespace SafeGuardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacaoController : ControllerBase
    {
        private readonly EstacaoService _estacaoService;

        public EstacaoController(EstacaoService estacaoService)
        {
            _estacaoService = estacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estacao>>> Get()
        {
            var estacoes = await _estacaoService.GetAllEstacoesAsync();
            return Ok(estacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estacao>> Get(int id)
        {
            try
            {
                var estacao = await _estacaoService.GetEstacaoByIdAsync(id);
                if (estacao == null) return NotFound();
                return Ok(estacao);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Estacao estacao)
        {
            try
            {
                await _estacaoService.UpdateEstacaoAsync(id, estacao);
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
        public async Task<ActionResult> Post(Estacao estacao)
        {
            try
            {
                var createdEstacao = await _estacaoService.AddEstacaoAsync(estacao);
                return CreatedAtAction(nameof(Get), new { id = createdEstacao.IdEstacao });
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
                await _estacaoService.DeleteEstacaoAsync(id);
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

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Estacao>>> GetByName(string nome)
        {
            var estacoes = await _estacaoService.GetEstacaoByNameAsync(nome);
            return Ok(estacoes);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Estacao>>> GetByStatus(string status)
        {
            var estacoes = await _estacaoService.GetEstacaoByStatusAsync(status);
            return Ok(estacoes);
        }

        [HttpGet("filtro/{nome}/{status}")]
        public async Task<ActionResult<IEnumerable<Estacao>>> Filtro(string nome, string status)
        {
            var estacoes = await _estacaoService.FiltroEstacaoAsync(nome, status);
            return Ok(estacoes);
        }
    }
}
