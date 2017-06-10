using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class LugarViajeConfiguration : EntityTypeConfiguration<LugarViaje>
    {
        public LugarViajeConfiguration()
    {
        Property(v => v.ciudad)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}