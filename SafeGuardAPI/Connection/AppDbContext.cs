using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Models;
using SafeGuardAPI.Data.Mappings;

namespace SafeGuardAPI.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Risco> Riscos { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Leitura> Leituras { get; set; }
        public DbSet<Estacao> Estacoes { get; set; }
        public DbSet<Alerta> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new RiscoMapping());
            modelBuilder.ApplyConfiguration(new SensorMapping());
            modelBuilder.ApplyConfiguration(new LeituraMapping());
            modelBuilder.ApplyConfiguration(new EstacaoMapping());
            modelBuilder.ApplyConfiguration(new AlertaMapping());
        }
    }
}
