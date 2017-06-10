[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MovieStore.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MovieStore.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace MovieStore.WebAPI.App_Start
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;
	using System.Web.Http;
    using _2011112243;

	using WebApiContrib.IoC.Ninject;

	public static class NinjectWebCommon 
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start() 
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}
		
		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}
		
		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				//Soporte para Web API
				GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IUnityOfWork>().To<UnityOfWork>();
			kernel.Bind<EmpTransporteDbContext>().To<EmpTransporteDbContext>();

			kernel.Bind<IBusRepository>().To<BusRepository>();
			kernel.Bind<IClienteRepository>().To<ClienteRepository>();
			kernel.Bind<IEmpleadoRepository>().To<EmpleadoRepository>();
            kernel.Bind<ILugarViajeRepository>().To<LugarViajeRepository>();
            kernel.Bind<IServicioRepository>().To<ServicioRepository>();
            kernel.Bind<ITipoComprobanteRepository>().To<TipoComprobanteRepository>();
            kernel.Bind<ITipoPagoRepository>().To<TipoPagoRepository>();
            kernel.Bind<IVentaRepository>().To<VentaRepository>();
          
        }        
	}
}
