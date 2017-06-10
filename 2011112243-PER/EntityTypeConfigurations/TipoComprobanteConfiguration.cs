using System.Data.Entity.ModelConfiguration;
using _2011112243;

namespace _2011112243
{
    public class TipoComprobanteConfiguration : EntityTypeConfiguration<TipoComprobante>
    {
        public TipoComprobanteConfiguration()
    {
        Property(v => v.TipodeComprobante)
            .IsRequired()
            .HasMaxLength(255);
    }
}

}