using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Data.Mappings
{
    public class AlertaMapping : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable("TB_ALERTA");
            builder.HasKey(a => a.IdAlerta);

            builder.Property(a => a.IdAlerta)
                .HasColumnName("ID_ALERTA")
                .IsRequired();

            builder.Property(a => a.Mensagem)
                .HasColumnName("MENSAGEM")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.DataAlerta)
                .HasColumnName("DATA_ALERTA")
                .IsRequired();

            builder.Property(a => a.RiscoId)
                .HasColumnName("ID_RISCO")
                .IsRequired();
        }
    }
}
