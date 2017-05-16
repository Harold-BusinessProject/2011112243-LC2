﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
	public interface IUnityOfWork : IDisposable
	{
	

		IVentaRepository Venta { get; }

		

		int SaveChanges();

	}
}
