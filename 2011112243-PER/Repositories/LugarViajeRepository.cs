using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _2011112243;
using System.Data.Entity;

namespace _2011112243
{
	public class LugarViajeRepository : IRepository<LugarViaje>, ILugarViajeRepository
    {
		private readonly EmpTransporteDbContext _Context;

		private LugarViajeRepository() : base ()
		{

		}

		public LugarViajeRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<LugarViaje>.Add(LugarViaje entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<LugarViaje>.AddRange(IEnumerable<LugarViaje> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<LugarViaje> IRepository<LugarViaje>.Find(Expression<Func<LugarViaje, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        LugarViaje IRepository<LugarViaje>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<LugarViaje> IRepository<LugarViaje>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<LugarViaje> ILugarViajeRepository.GetLugarViajeByTipoLugar(TipoLugar tipoLugar)
		{
            return _Context.LugarViaje;
        }




		void IRepository<LugarViaje>.Remove(LugarViaje entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<LugarViaje>.RemoveRange(IEnumerable<LugarViaje> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<LugarViaje>.Update(LugarViaje entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<LugarViaje>.UpdateRange(IEnumerable<LugarViaje> entities)
		{
			throw new NotImplementedException();
		}
	}
}
