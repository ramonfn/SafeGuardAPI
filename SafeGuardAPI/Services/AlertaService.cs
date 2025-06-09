using SafeGuardAPI.Models;
using SafeGuardAPI.Repository;
using SafeGuardAPI.Validations;
using SafeGuardAPI.Exceptions;
using System.Threading.Tasks;

namespace SafeGuardAPI.Services
{
    public class AlertaService
    {
        private readonly AlertaRepository _repository;

        public AlertaService(AlertaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Alerta>> GetAllAlertasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Alerta?> GetAlertaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Alerta> AddAlertaAsync(Alerta alerta)
        {
            AlertaValidation.ValidadeAlerta(alerta); // Validação
            await _repository.AddAsync(alerta);
            return alerta;
        }

        public async Task UpdateAlertaAsync(int id, Alerta alerta)
        {
            if (id != alerta.IdAlerta)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID do Alerta que deseja ser alterado");
            }
            AlertaValidation.ValidadeAlerta(alerta); // Validação
            await _repository.UpdateAsync(alerta);
        }

        public async Task DeleteAlertaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var alerta = await _repository.GetByIdAsync(id);

            if (alerta == null)
            {
                throw new NotFoundException($"Alerta com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(alerta);
        }

        public async Task<IEnumerable<Alerta>> GetAlertaBySensorIdAsync(int sensorId)
        {
            if (sensorId == 0)
            {
                throw new ArgumentException("O ID do sensor não pode ser zero.");
            }

            return await _repository.GetBySensorIdAsync(sensorId);
        }

        public async Task<IEnumerable<Alerta>> FiltroAlertaAsync(int sensorId, DateTime dataHora)
        {
            if (sensorId == 0 && dataHora == default)
            {
                throw new ArgumentException("O ID do sensor não pode ser zero e a dataHora não pode ser inválida");
            }
            return await _repository.FiltrarAsync(sensorId, dataHora);
        }
    }
}
