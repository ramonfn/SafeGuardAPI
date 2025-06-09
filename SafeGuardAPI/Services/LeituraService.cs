using SafeGuardAPI.Models;
using SafeGuardAPI.Repository;
using SafeGuardAPI.Validations;
using SafeGuardAPI.Exceptions;
using System.Threading.Tasks;

namespace SafeGuardAPI.Services
{
    public class LeituraService
    {
        private readonly LeituraRepository _repository;

        public LeituraService(LeituraRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Leitura>> GetAllLeiturasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Leitura?> GetLeituraByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Leitura> AddLeituraAsync(Leitura leitura)
        {
            LeituraValidation.ValidadeLeitura(leitura); // Validação
            await _repository.AddAsync(leitura);
            return leitura;
        }

        public async Task UpdateLeituraAsync(int id, Leitura leitura)
        {
            if (id != leitura.IdLeitura)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID da Leitura que deseja ser alterada");
            }
            LeituraValidation.ValidadeLeitura(leitura); // Validação
            await _repository.UpdateAsync(leitura);
        }

        public async Task DeleteLeituraAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var leitura = await _repository.GetByIdAsync(id);

            if (leitura == null)
            {
                throw new NotFoundException($"Leitura com ID {id} não foi encontrada no sistema");
            }

            await _repository.DeleteAsync(leitura);
        }

        public async Task<IEnumerable<Leitura>> GetLeituraBySensorIdAsync(int sensorId)
        {
            if (sensorId == 0)
            {
                throw new ArgumentException("O ID do sensor não pode ser zero.");
            }

            return await _repository.GetBySensorIdAsync(sensorId);
        }

        public async Task<IEnumerable<Leitura>> FiltroLeituraAsync(int sensorId, DateTime dataHora)
        {
            if (sensorId == 0 && dataHora == default)
            {
                throw new ArgumentException("O ID do sensor não pode ser zero e a dataHora não pode ser inválida");
            }
            return await _repository.FiltrarAsync(sensorId, dataHora);
        }
    }
}
