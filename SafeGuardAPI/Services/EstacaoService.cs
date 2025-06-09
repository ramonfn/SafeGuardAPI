using SafeGuardAPI.Models;
using SafeGuardAPI.Repository;
using SafeGuardAPI.Validations;
using SafeGuardAPI.Exceptions;
using System.Threading.Tasks;

namespace SafeGuardAPI.Services
{
    public class EstacaoService
    {
        private readonly EstacaoRepository _repository;

        public EstacaoService(EstacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Estacao>> GetAllEstacoesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Estacao?> GetEstacaoByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Estacao> AddEstacaoAsync(Estacao estacao)
        {
            EstacaoValidation.ValidadeEstacao(estacao); // Validação
            await _repository.AddAsync(estacao);
            return estacao;
        }

        public async Task UpdateEstacaoAsync(int id, Estacao estacao)
        {
            if (id != estacao.IdEstacao)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID da Estação que deseja ser alterada");
            }
            EstacaoValidation.ValidadeEstacao(estacao); // Validação
            await _repository.UpdateAsync(estacao);
        }

        public async Task DeleteEstacaoAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var estacao = await _repository.GetByIdAsync(id);

            if (estacao == null)
            {
                throw new NotFoundException($"Estação com ID {id} não foi encontrada no sistema");
            }

            await _repository.DeleteAsync(estacao);
        }

        public async Task<IEnumerable<Estacao>> GetEstacaoByNameAsync(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio.");
            }

            return await _repository.GetByNameAsync(nome);
        }

        public async Task<IEnumerable<Estacao>> GetEstacaoByStatusAsync(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("O status não pode ser nulo ou vazio.");
            }

            return await _repository.GetByStatusAsync(status);
        }

        public async Task<IEnumerable<Estacao>> FiltroEstacaoAsync(string nome, string status)
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("O nome ou o status não pode ser nulo.");
            }

            return await _repository.FiltrarAsync(nome, status);
        }
    }
}
