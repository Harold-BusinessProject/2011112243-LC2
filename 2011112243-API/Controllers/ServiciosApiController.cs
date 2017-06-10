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
	public class ServiciosApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public ServiciosApiController()
		{

		}

		public ServiciosApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var Servicios = _UnityOfWork.Servicio.GetAll();

			if (Servicios == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var ServicioDTO = new List<ServicioDTO>();

			foreach (var servicio in Servicios)
            ServicioDTO.Add(Mapper.Map<Servicio, ServicioDTO>(servicio));

			return Ok(ServicioDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var servicio = _UnityOfWork.Servicio.Get(id);

			if (servicio == null)
				return NotFound();

			return Ok(Mapper.Map<Servicio, ServicioDTO>(servicio));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, ServicioDTO servicioDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var servicioInPersistence = _UnityOfWork.Servicio.Get(id);
			if (servicioInPersistence == null)
				return NotFound();

			Mapper.Map<ServicioDTO, Servicio>(servicioDTO, servicioInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(servicioDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(ServicioDTO servicioDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var servicio = Mapper.Map<ServicioDTO, Servicio>(servicioDTO);

			_UnityOfWork.Servicio.Add(servicio);
			_UnityOfWork.SaveChanges();

        servicioDTO.idServicio = servicio.idServicio;

			return Created(new Uri(Request.RequestUri + "/" + servicio.idServicio), servicioDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var servicioInDataBase = _UnityOfWork.Servicio.Get(id);
			if (servicioInDataBase == null)
				return NotFound();

			_UnityOfWork.Servicio.Remove(servicioInDataBase);
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