using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface IVentaRepository : IRepository<Venta>
	{
		IEnumerable<Venta> GetVentaByCliente(Cliente cliente);

		IEnumerable<Venta> GetVentaByAdministrativo(Administrativo administrativo);

		IEnumerable<Venta> GetVentaByClienteAndAdministrativo(Cliente cliente, Administrativo administrativo);

    }
}


