using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface IBusRepository : IRepository<Bus>
	{
		IEnumerable<Bus> GetBusByTripulacion(Tripulacion tripulacion);

	
	}
}
