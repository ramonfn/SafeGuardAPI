using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Connection;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Repository
{
    public class EstacaoRepository
    {
        private readonly AppDbContext _context;

        public EstacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estacao>> GetAllAsync()
        {
            return await _context.Estacoes.ToListAsync();
        }

        public async Task<Estacao?> GetByIdAsync(int id)
        {
            return await _context.Estacoes.FindAsync(id);
        }

        public async Task AddAsync(Estacao estacao)
        {
            _context.Estacoes.Add(estacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estacao estacao)
        {
            _context.Entry(estacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Estacao estacao)
        {
            _context.Estacoes.Remove(estacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Estacao>> GetByNameAsync(string nome)
        {
            return await _context.Estacoes.Where(e => e.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<IEnumerable<Estacao>> GetByStatusAsync(string status)
        {
            return await _context.Estacoes.Where(e => e.Status.Contains(status)).ToListAsync();
        }

        public async Task<IEnumerable<Estacao>> FiltrarAsync(string nome, string status)
        {
            return await _context.Estacoes
                .Where(e => e.Nome.Contains(nome) && e.Status.Contains(status))
                .ToListAsync();
        }
    }
}
