using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Data.Mappings
{
    public class EstacaoMapping : IEntityTypeConfiguration<Estacao>
    {
        public void Configure(EntityTypeBuilder<Estacao> builder)
        {
            builder.ToTable("TB_ESTACAO");
            builder.HasKey(e => e.IdEstacao);

            builder.Property(e => e.IdEstacao)
                .HasColumnName("ID_ESTACAO")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("STATUS")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
