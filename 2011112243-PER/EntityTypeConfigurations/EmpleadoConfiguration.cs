using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class EmpleadoConfiguration : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguration()
    {
        Property(v => v.nom)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}