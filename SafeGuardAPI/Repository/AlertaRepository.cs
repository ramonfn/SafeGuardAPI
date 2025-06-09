using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Connection;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Repository
{
    public class AlertaRepository
    {
        private readonly AppDbContext _context;

        public AlertaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Alerta>> GetAllAsync()
        {
            return await _context.Alertas.ToListAsync();
        }

        public async Task<Alerta?> GetByIdAsync(int id)
        {
            return await _context.Alertas.FindAsync(id);
        }

        public async Task AddAsync(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Alerta alerta)
        {
            _context.Entry(alerta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Alerta alerta)
        {
            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alerta>> GetBySensorIdAsync(int sensorId)
        {
            return await _context.Alertas.Where(a => a.RiscoId == sensorId).ToListAsync();
        }

        public async Task<IEnumerable<Alerta>> FiltrarAsync(int sensorId, DateTime dataHora)
        {
            return await _context.Alertas
                .Where(a => a.RiscoId == sensorId && a.DataAlerta >= dataHora)
                .ToListAsync();
        }
    }
}
