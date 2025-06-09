using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Data.Mappings
{
    public class RiscoMapping : IEntityTypeConfiguration<Risco>
    {
        public void Configure(EntityTypeBuilder<Risco> builder)
        {
            builder.ToTable("TB_RISCO");
            builder.HasKey(r => r.IdRisco);

            builder.Property(r => r.IdRisco)
                .HasColumnName("ID_RISCO")
                .IsRequired();

            builder.Property(r => r.IdEstacao)
                .HasColumnName("ID_ESTACAO")
                .IsRequired();

            builder.Property(r => r.Nivel)
                .HasColumnName("NIVEL")
                .IsRequired();

            builder.Property(r => r.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
