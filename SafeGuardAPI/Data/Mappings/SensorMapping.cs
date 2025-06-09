using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Data.Mappings
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("TB_SENSOR");
            builder.HasKey(s => s.IdSensor);

            builder.Property(s => s.IdSensor)
                .HasColumnName("ID_SENSOR")
                .IsRequired();

            builder.Property(s => s.TipoSensor)
                .HasColumnName("TIPO_SENSOR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.EstacaoId)
                .HasColumnName("ID_ESTACAO")
                .IsRequired();
        }
    }
}
