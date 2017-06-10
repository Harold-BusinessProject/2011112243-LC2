using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		IEnumerable<Cliente> GetClienteByVenta(Venta venta);

	
	}
}
