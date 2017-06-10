using System.Web;
using System.Web.Mvc;

namespace _2011112243.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
			//filtro para redireccionar a un manejo de error cuando se genera un error en una accion.
			filters.Add(new HandleErrorAttribute());

			//filtro para configurar la aplicacion para que siempre se autentique al usuario.
			filters.Add(new AuthorizeAttribute());

			//filtro para configurar la aplicacion para que siempre utilice https
			filters.Add(new RequireHttpsAttribute());
		}
    }
}
