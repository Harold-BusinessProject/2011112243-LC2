using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface ITipoPagoRepository : IRepository<TipoPago>
	{
		IEnumerable<TipoPago> GetTipoPagoByVenta(Venta venta);

		}
}
