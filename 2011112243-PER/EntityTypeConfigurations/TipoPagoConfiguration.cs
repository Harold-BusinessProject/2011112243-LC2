using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class TipoPagoConfiguration : EntityTypeConfiguration<TipoPago>
    {
        public TipoPagoConfiguration()
    {
        Property(v => v.tipodePago)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}