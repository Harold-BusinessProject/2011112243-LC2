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
	public class VentaRepository : IRepository<Venta>, IVentaRepository
	{
		private readonly EmpTransporteDbContext _Context;

		private VentaRepository() : base ()
		{

		}

		public VentaRepository (EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<Venta>.Add(Venta entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Venta>.AddRange(IEnumerable<Venta> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Venta> IRepository<Venta>.Find(Expression<Func<Venta, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        Venta IRepository<Venta>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Venta> IRepository<Venta>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<Venta> IVentaRepository.GetVentaByCliente(Cliente cliente)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Venta> IVentaRepository.GetVentaByAdministrativo(Administrativo administrativo)
		{
            return _Context.Venta;
                   
		}

		IEnumerable<Venta> IVentaRepository.GetVentaByClienteAndAdministrativo(Cliente cliente, Administrativo administrativo)
		{
			return _Context.Venta
				.Where(v => v._Cliente == cliente && v._Administrativo == administrativo)
				.OrderByDescending(v => v._Cliente.nom);
		}


		void IRepository<Venta>.Remove(Venta entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Venta>.RemoveRange(IEnumerable<Venta> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<Venta>.Update(Venta entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Venta>.UpdateRange(IEnumerable<Venta> entities)
		{
			throw new NotImplementedException();
		}
	}
}
