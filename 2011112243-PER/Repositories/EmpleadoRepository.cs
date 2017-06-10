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
	public class EmpleadoRepository : IRepository<Empleado>, IEmpleadoRepository
	{
		private readonly EmpTransporteDbContext _Context;

		private EmpleadoRepository() : base ()
		{

		}

		public EmpleadoRepository(EmpTransporteDbContext context)
		{
			_Context = context;
		}

		void IRepository<Empleado>.Add(Empleado entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Empleado>.AddRange(IEnumerable<Empleado> entities)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Empleado> IRepository<Empleado>.Find(Expression<Func<Empleado, bool>> predicate)
		{
			throw new NotImplementedException();
		}

        Empleado IRepository<Empleado>.Get(int? id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Empleado> IRepository<Empleado>.GetAll()
		{
			throw new NotImplementedException();
		}

		IEnumerable<Empleado> IEmpleadoRepository.GetEmpleadoByNombre(string nombre)
		{
            return _Context.Empleado;
        }

	
        


		void IRepository<Empleado>.Remove(Empleado entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Empleado>.RemoveRange(IEnumerable<Empleado> entities)
		{
			throw new NotImplementedException();
		}

		void IRepository<Empleado>.Update(Empleado entity)
		{
			throw new NotImplementedException();
		}

		void IRepository<Empleado>.UpdateRange(IEnumerable<Empleado> entities)
		{
			throw new NotImplementedException();
		}
	}
}
