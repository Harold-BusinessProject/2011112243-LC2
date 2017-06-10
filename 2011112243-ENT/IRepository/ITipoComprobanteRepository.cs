using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface ITipoComprobanteRepository : IRepository<TipoComprobante>
	{
		IEnumerable<TipoComprobante> GetTipoComprobanteByVenta(Venta venta);


	}
}
