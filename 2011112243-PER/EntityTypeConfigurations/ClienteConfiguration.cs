using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
    {
        Property(v => v.nom)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}