using SafeGuardAPI.Models;
using SafeGuardAPI.Repository;
using SafeGuardAPI.Validations;
using SafeGuardAPI.Exceptions;
using System.Threading.Tasks;

namespace SafeGuardAPI.Services
{
    public class RiscoService
    {
        private readonly RiscoRepository _repository;

        public RiscoService(RiscoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Risco>> GetAllRiscosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Risco?> GetRiscoByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID n�o pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Risco> AddRiscoAsync(Risco risco)
        {
            RiscoValidation.ValidadeRisco(risco); // Valida��o
            await _repository.AddAsync(risco);
            return risco;
        }

        public async Task UpdateRiscoAsync(int id, Risco risco)
        {
            if (id != risco.IdRisco)
            {
                throw new ArgumentException("O ID na URL n�o corresponde ao ID do Risco que deseja ser alterado");
            }
            RiscoValidation.ValidadeRisco(risco); // Valida��o
            await _repository.UpdateAsync(risco);
        }

        public async Task DeleteRiscoAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID n�o pode ser zero.");
            }

            var risco = await _repository.GetByIdAsync(id);

            if (risco == null)
            {
                throw new NotFoundException($"Risco com ID {id} n�o foi encontrado no sistema");
            }

            await _repository.DeleteAsync(risco);
        }

        public async Task<IEnumerable<Risco>> GetRiscoByEstacaoIdAsync(int estacaoId)
        {
            if (estacaoId == 0)
            {
                throw new ArgumentException("O ID da esta��o n�o pode ser zero.");
            }

            return await _repository.GetByEstacaoIdAsync(estacaoId);
        }

        public async Task<IEnumerable<Risco>> FiltroRiscoAsync(int estacaoId, int nivel)
        {
            if (estacaoId == 0 && nivel == 0)
            {
                throw new ArgumentException("O ID da esta��o n�o pode ser zero e o n�vel n�o pode ser zero.");
            }
            return await _repository.FiltrarAsync(estacaoId, nivel);
        }
    }
}
