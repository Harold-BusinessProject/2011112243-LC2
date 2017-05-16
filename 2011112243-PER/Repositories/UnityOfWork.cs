using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2011112243;
using System.Data.Entity;

namespace _2011112243
{
	public class UnityOfWork : IUnityOfWork
	{
		private readonly EmpTransporteDbContext _Context;
		private static  UnityOfWork _Instance;
		private static readonly object _Lock = new object();

	
		public IVentaRepository Ventas { get; private set; }

		private UnityOfWork()
		{
			_Context = new EmpTransporteDbContext();



            Ventas = new VentaRepository(_Context);

		}

		public static UnityOfWork Instance
		{
			get
			{
				lock (_Lock)
				{
					if (_Instance == null)
						_Instance = new UnityOfWork();
				}

				return _Instance;
			}
		}

        public IVentaRepository Venta => _Instance.Venta;

        void IDisposable.Dispose()
		{
			_Context.Dispose();
		}

		int IUnityOfWork.SaveChanges()
		{
			return _Context.SaveChanges();
		}
	}
}
