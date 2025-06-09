using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Data.Mappings
{
    public class LeituraMapping : IEntityTypeConfiguration<Leitura>
    {
        public void Configure(EntityTypeBuilder<Leitura> builder)
        {
            builder.ToTable("TB_LEITURA");
            builder.HasKey(l => l.IdLeitura);

            builder.Property(l => l.IdLeitura)
                .HasColumnName("ID_LEITURA")
                .IsRequired();

            builder.Property(l => l.SensorId)
                .HasColumnName("ID_SENSOR")
                .IsRequired();

            builder.Property(l => l.DataHora)
                .HasColumnName("DATA_HORA")
                .IsRequired();

            builder.Property(l => l.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
