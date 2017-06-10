using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2011112243;


namespace _2011112243
{
	public class UnityOfWork : IUnityOfWork
	{
		private readonly EmpTransporteDbContext _Context;


        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IVentaRepository Ventas { get; private set; }
        public IBusRepository Buses { get; private set; }
        public IClienteRepository Clientes { get; private set; }
       
        public ILugarViajeRepository LugarViajes { get; private set; }
        public IServicioRepository Servicios { get; private set; }
        public ITipoComprobanteRepository TipoComprobantes { get; private set; }
        public ITipoPagoRepository TipoPagos { get; private set; }
        
       
        public IEmpleadoRepository Empleados { get; private set; }
        public UnityOfWork()
            {

            }


        public IVentaRepository Venta => _Instance.Venta;
        public IBusRepository Bus => _Instance.Bus;
        public IClienteRepository Cliente => _Instance.Cliente;
        
        public ILugarViajeRepository LugarViaje => _Instance.LugarViaje;
        public IServicioRepository Servicio => _Instance.Servicio;
        public ITipoComprobanteRepository TipoComprobante => _Instance.TipoComprobante;
        public ITipoPagoRepository TipoPago => _Instance.TipoPago;
   
       
        public IEmpleadoRepository Empleado => _Instance.Empleado;

        public UnityOfWork(EmpTransporteDbContext context)
        {
            _Context = context;
            Ventas = new VentaRepository(_Context);
            Buses = new BusRepository(_Context);
            Clientes = new ClienteRepository(_Context);
          
            LugarViajes = new LugarViajeRepository(_Context);
            Servicios = new ServicioRepository(_Context);
            TipoComprobantes = new TipoComprobanteRepository(_Context);
            TipoPagos = new TipoPagoRepository(_Context);
           
            
            Empleados = new EmpleadoRepository(_Context);


        }

       


        public void  Dispose()
        {
            _Context.Dispose();
        }


      public  int   SaveChanges()
		{
			return _Context.SaveChanges();
		}

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.EntityState.Modified;
        }
    }
}
	

