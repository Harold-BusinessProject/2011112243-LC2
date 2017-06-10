using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class BusConfiguration : EntityTypeConfiguration<Bus>
    {
        public BusConfiguration()
    {
        Property(v => v.marca)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}