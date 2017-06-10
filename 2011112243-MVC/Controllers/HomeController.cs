using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace _2011112243.MVC
{
	[AllowAnonymous] 
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Empresa de Transporte Rapido.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "USMP.FIA.";

			return View();
		}
	}
}