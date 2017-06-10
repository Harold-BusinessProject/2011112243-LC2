using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class ServicioConfiguration : EntityTypeConfiguration<Servicio>
    {
        public ServicioConfiguration()
    {
        Property(v => v.tipoServicio)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}