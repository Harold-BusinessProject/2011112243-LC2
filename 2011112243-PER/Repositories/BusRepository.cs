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
	public class BusRepository : IRepository<Bus>, IBusRepository
	{
		private readonly EmpTransporteDbContext _Context;

		private BusRepository() : base ()
		{

		}

		public BusRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<Bus>.Add(Bus entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Bus>.AddRange(IEnumerable<Bus> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Bus> IRepository<Bus>.Find(Expression<Func<Bus, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        Bus IRepository<Bus>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Bus> IRepository<Bus>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<Bus> IBusRepository.GetBusByTripulacion(Tripulacion tripulacion)
		{
            return _Context.Bus;
        }

	
        


		void IRepository<Bus>.Remove(Bus entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Bus>.RemoveRange(IEnumerable<Bus> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<Bus>.Update(Bus entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Bus>.UpdateRange(IEnumerable<Bus> entities)
		{
			throw new NotImplementedException();
		}
	}
}
