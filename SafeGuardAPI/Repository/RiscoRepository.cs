using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Connection;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Repository
{
    public class RiscoRepository
    {
        private readonly AppDbContext _context;

        public RiscoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Risco>> GetAllAsync()
        {
            return await _context.Riscos.ToListAsync();
        }

        public async Task<Risco?> GetByIdAsync(int id)
        {
            return await _context.Riscos.FindAsync(id);
        }

        public async Task AddAsync(Risco risco)
        {
            _context.Riscos.Add(risco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Risco risco)
        {
            _context.Entry(risco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Risco risco)
        {
            _context.Riscos.Remove(risco);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Risco>> GetByEstacaoIdAsync(int estacaoId)
        {
            return await _context.Riscos.Where(r => r.IdEstacao == estacaoId).ToListAsync();
        }

        public async Task<IEnumerable<Risco>> FiltrarAsync(int estacaoId, int nivel)
        {
            return await _context.Riscos
                .Where(r => r.IdEstacao == estacaoId && r.Nivel >= nivel)
                .ToListAsync();
        }
    }
}
