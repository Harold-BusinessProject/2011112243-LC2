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
	public class TipoComprobanteRepository : IRepository<TipoComprobante>, ITipoComprobanteRepository
    {
		private readonly EmpTransporteDbContext _Context;

		private TipoComprobanteRepository() : base ()
		{

		}

		public TipoComprobanteRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<TipoComprobante>.Add(TipoComprobante entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoComprobante>.AddRange(IEnumerable<TipoComprobante> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<TipoComprobante> IRepository<TipoComprobante>.Find(Expression<Func<TipoComprobante, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        TipoComprobante IRepository<TipoComprobante>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<TipoComprobante> IRepository<TipoComprobante>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<TipoComprobante> ITipoComprobanteRepository.GetTipoComprobanteByVenta(Venta venta)	{
            return _Context.TipoComprobante;
        }


		void IRepository<TipoComprobante>.Remove(TipoComprobante entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoComprobante>.RemoveRange(IEnumerable<TipoComprobante> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoComprobante>.Update(TipoComprobante entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<TipoComprobante>.UpdateRange(IEnumerable<TipoComprobante> entities)
		{
			throw new NotImplementedException();
		}
	}
}
