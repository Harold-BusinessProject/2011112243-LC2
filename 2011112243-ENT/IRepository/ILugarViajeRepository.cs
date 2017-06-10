using System.Collections.Generic;
using _2011112243;

namespace _2011112243
{
	public interface ILugarViajeRepository : IRepository<LugarViaje>
	{
		IEnumerable<LugarViaje> GetLugarViajeByTipoLugar(TipoLugar tipoLugar);
        
	}
}
