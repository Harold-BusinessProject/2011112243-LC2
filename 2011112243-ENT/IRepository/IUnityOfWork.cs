using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
	public interface IUnityOfWork : IDisposable
	{
	

		IVentaRepository Venta { get; }
        IBusRepository Bus { get; }
        IClienteRepository Cliente { get; }
       
        ILugarViajeRepository LugarViaje { get; }
        IServicioRepository Servicio { get; }
        ITipoComprobanteRepository TipoComprobante { get; }
        ITipoPagoRepository TipoPago { get; }
     
      
        IEmpleadoRepository Empleado { get; }



        int SaveChanges();
        void StateModified(object entity);
    }
}
