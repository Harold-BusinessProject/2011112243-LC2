using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
    {
        Property(v => v._Administrativo.nom)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}