using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface IEmpleadoRepository : IRepository<Empleado>
	{
		IEnumerable<Empleado> GetEmpleadoByNombre(string nombre );

	
	}
}
