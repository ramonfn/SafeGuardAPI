using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Connection;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Repository
{
    public class LeituraRepository
    {
        private readonly AppDbContext _context;

        public LeituraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leitura>> GetAllAsync()
        {
            return await _context.Leituras.ToListAsync();
        }

        public async Task<Leitura?> GetByIdAsync(int id)
        {
            return await _context.Leituras.FindAsync(id);
        }

        public async Task AddAsync(Leitura leitura)
        {
            _context.Leituras.Add(leitura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Leitura leitura)
        {
            _context.Entry(leitura).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Leitura leitura)
        {
            _context.Leituras.Remove(leitura);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Leitura>> GetBySensorIdAsync(int sensorId)
        {
            return await _context.Leituras.Where(l => l.SensorId == sensorId).ToListAsync();
        }

        public async Task<IEnumerable<Leitura>> FiltrarAsync(int sensorId, DateTime dataHora)
        {
            return await _context.Leituras
                .Where(l => l.SensorId == sensorId && l.DataHora >= dataHora)
                .ToListAsync();
        }
    }
}
