using SafeGuardAPI.Models;
using SafeGuardAPI.Repository;
using SafeGuardAPI.Validations;
using SafeGuardAPI.Exceptions;
using System.Threading.Tasks;

namespace SafeGuardAPI.Services
{
    public class SensorService
    {
        private readonly SensorRepository _repository;

        public SensorService(SensorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Sensor>> GetAllSensorsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Sensor?> GetSensorByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Sensor> AddSensorAsync(Sensor sensor)
        {
            SensorValidation.ValidadeSensor(sensor); // Validação
            await _repository.AddAsync(sensor);
            return sensor;
        }

        public async Task UpdateSensorAsync(int id, Sensor sensor)
        {
            if (id != sensor.IdSensor)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID do Sensor que deseja ser alterado");
            }
            SensorValidation.ValidadeSensor(sensor); // Validação
            await _repository.UpdateAsync(sensor);
        }

        public async Task DeleteSensorAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var sensor = await _repository.GetByIdAsync(id);

            if (sensor == null)
            {
                throw new NotFoundException($"Sensor com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(sensor);
        }

        public async Task<IEnumerable<Sensor>> GetSensorByEstacaoIdAsync(int estacaoId)
        {
            if (estacaoId == 0)
            {
                throw new ArgumentException("O ID da estação não pode ser zero.");
            }

            return await _repository.GetByEstacaoIdAsync(estacaoId);
        }

        public async Task<IEnumerable<Sensor>> FiltroSensorAsync(int estacaoId, string tipoSensor)
        {
            if (estacaoId == 0 && string.IsNullOrEmpty(tipoSensor))
            {
                throw new ArgumentException("O ID da estação não pode ser zero e o tipo de sensor não pode ser nulo");
            }
            return await _repository.FiltrarAsync(estacaoId, tipoSensor);
        }
    }
}
