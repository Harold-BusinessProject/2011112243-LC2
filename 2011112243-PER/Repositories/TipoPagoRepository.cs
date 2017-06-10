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
	public class TipoPagoRepository : IRepository<TipoPago>, ITipoPagoRepository
	{
		private readonly EmpTransporteDbContext _Context;

		private TipoPagoRepository() : base ()
		{

		}

		public TipoPagoRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<TipoPago>.Add(TipoPago entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoPago>.AddRange(IEnumerable<TipoPago> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<TipoPago> IRepository<TipoPago>.Find(Expression<Func<TipoPago, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        TipoPago IRepository<TipoPago>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<TipoPago> IRepository<TipoPago>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<TipoPago> ITipoPagoRepository.GetTipoPagoByVenta(Venta venta)
		{
            return _Context.TipoPago;
        }

	
		void IRepository<TipoPago>.Remove(TipoPago entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoPago>.RemoveRange(IEnumerable<TipoPago> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoPago>.Update(TipoPago entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoPago>.UpdateRange(IEnumerable<TipoPago> entities)
		{
			throw new NotImplementedException();
		}
	}
}
