using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Connection;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Repository
{
    public class SensorRepository
    {
        private readonly AppDbContext _context;

        public SensorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sensor>> GetAllAsync()
        {
            return await _context.Sensores.ToListAsync();
        }

        public async Task<Sensor?> GetByIdAsync(int id)
        {
            return await _context.Sensores.FindAsync(id);
        }

        public async Task AddAsync(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sensor sensor)
        {
            _context.Entry(sensor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Sensor sensor)
        {
            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sensor>> GetByEstacaoIdAsync(int estacaoId)
        {
            return await _context.Sensores.Where(s => s.EstacaoId == estacaoId).ToListAsync();
        }

        public async Task<IEnumerable<Sensor>> FiltrarAsync(int estacaoId, string tipoSensor)
        {
            return await _context.Sensores
                .Where(s => s.EstacaoId == estacaoId && s.TipoSensor.Contains(tipoSensor))
                .ToListAsync();
        }
    }
}
