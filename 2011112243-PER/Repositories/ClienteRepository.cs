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
	public class ClienteRepository : IRepository<Cliente>, IClienteRepository
	{
		private readonly EmpTransporteDbContext _Context;

		private ClienteRepository() : base ()
		{

		}

		public ClienteRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<Cliente>.Add(Cliente entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Cliente>.AddRange(IEnumerable<Cliente> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Cliente> IRepository<Cliente>.Find(Expression<Func<Cliente, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        Cliente IRepository<Cliente>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Cliente> IRepository<Cliente>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<Cliente> IClienteRepository.GetClienteByVenta(Venta venta)
		{
            return _Context.Cliente;
        }

		

		


		void IRepository<Cliente>.Remove(Cliente entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Cliente>.RemoveRange(IEnumerable<Cliente> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<Cliente>.Update(Cliente entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Cliente>.UpdateRange(IEnumerable<Cliente> entities)
		{
			throw new NotImplementedException();
		}
	}
}
