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
	public class ServicioRepository : IRepository<Servicio>, IServicioRepository
	{
		private readonly EmpTransporteDbContext _Context;

		private ServicioRepository() : base ()
		{

		}

		public ServicioRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<Servicio>.Add(Servicio entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Servicio>.AddRange(IEnumerable<Servicio> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Servicio> IRepository<Servicio>.Find(Expression<Func<Servicio, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        Servicio IRepository<Servicio>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Servicio> IRepository<Servicio>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<Servicio> IServicioRepository.GetServicioByVenta(Venta venta)
        {
            return _Context.Servicio;
        }


		void IRepository<Servicio>.Remove(Servicio entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Servicio>.RemoveRange(IEnumerable<Servicio> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<Servicio>.Update(Servicio entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Servicio>.UpdateRange(IEnumerable<Servicio> entities)
		{
			throw new NotImplementedException();
		}
	}
}
