using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _2011112243;

using AutoMapper;

namespace _2011112243.WebAPI
{
	public class GenresApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public GenresApiController()
		{

		}

		public GenresApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var Ventas = _UnityOfWork.Venta.GetAll();

			if (Ventas == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var VentaDTO = new List<VentaDTO>();

			foreach (var venta in Ventas)
            VentaDTO.Add(Mapper.Map<Venta, VentaDTO>(venta));

			return Ok(VentaDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var venta = _UnityOfWork.Venta.Get(id);

			if (venta == null)
				return NotFound();

			return Ok(Mapper.Map<Venta, VentaDTO>(venta));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, VentaDTO ventaDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var ventaInPersistence = _UnityOfWork.Venta.Get(id);
			if (ventaInPersistence == null)
				return NotFound();

			Mapper.Map<VentaDTO, Venta>(ventaDTO, ventaInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(ventaDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(VentaDTO ventaDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var venta = Mapper.Map<VentaDTO, Venta>(ventaDTO);

			_UnityOfWork.Venta.Add(venta);
			_UnityOfWork.SaveChanges();

        ventaDTO.idVenta = venta.idVenta;

			return Created(new Uri(Request.RequestUri + "/" + venta.idVenta), ventaDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var ventaInDataBase = _UnityOfWork.Venta.Get(id);
			if (ventaInDataBase == null)
				return NotFound();

			_UnityOfWork.Venta.Remove(ventaInDataBase);
			_UnityOfWork.SaveChanges();

			return Ok();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_UnityOfWork.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}