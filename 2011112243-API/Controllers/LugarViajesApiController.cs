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
	public class LugarViajeApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public LugarViajeApiController()
		{

		}

		public LugarViajeApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var LugarViajes = _UnityOfWork.LugarViaje.GetAll();

			if (LugarViajes == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var LugarViajeDTO = new List<LugarViajeDTO>();

			foreach (var lugarViaje in LugarViajes)
            LugarViajeDTO.Add(Mapper.Map<LugarViaje, LugarViajeDTO>(lugarViaje));

			return Ok(LugarViajeDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var lugarViaje = _UnityOfWork.LugarViaje.Get(id);

			if (lugarViaje == null)
				return NotFound();

			return Ok(Mapper.Map<LugarViaje, LugarViajeDTO>(lugarViaje));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, LugarViajeDTO lugarViajeDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var lugarViajeInPersistence = _UnityOfWork.LugarViaje.Get(id);
			if (lugarViajeInPersistence == null)
				return NotFound();

			Mapper.Map<LugarViajeDTO, LugarViaje>(lugarViajeDTO, lugarViajeInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(lugarViajeDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(LugarViajeDTO lugarViajeDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var lugarViaje = Mapper.Map<LugarViajeDTO, LugarViaje>(lugarViajeDTO);

			_UnityOfWork.LugarViaje.Add(lugarViaje);
			_UnityOfWork.SaveChanges();

            lugarViajeDTO.idLugarViaje = lugarViaje.idLugarViaje;

			return Created(new Uri(Request.RequestUri + "/" + lugarViaje.idLugarViaje), lugarViajeDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var lugarViajeInDataBase = _UnityOfWork.LugarViaje.Get(id);
			if (lugarViajeInDataBase == null)
				return NotFound();

			_UnityOfWork.LugarViaje.Remove(lugarViajeInDataBase);
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