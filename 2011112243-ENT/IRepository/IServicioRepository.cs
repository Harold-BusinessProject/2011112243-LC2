using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface IServicioRepository : IRepository<Servicio>
	{
		IEnumerable<Servicio> GetServicioByVenta(Venta venta);

	}
}
