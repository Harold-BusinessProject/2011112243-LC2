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
	public class BusesApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public BusesApiController()
		{

		}

		public BusesApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var Buses = _UnityOfWork.Bus.GetAll();

			if (Buses == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var BusDTO = new List<BusDTO>();

			foreach (var bus in Buses)
            BusDTO.Add(Mapper.Map<Bus, BusDTO>(bus));

			return Ok(BusDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var bus = _UnityOfWork.Bus.Get(id);

			if (bus == null)
				return NotFound();

			return Ok(Mapper.Map<Bus, BusDTO>(bus));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, BusDTO busDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var busInPersistence = _UnityOfWork.Bus.Get(id);
			if (busInPersistence == null)
				return NotFound();

			Mapper.Map<BusDTO, Bus>(busDTO, busInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(busDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(BusDTO busDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var bus = Mapper.Map<BusDTO, Bus>(busDTO);

			_UnityOfWork.Bus.Add(bus);
			_UnityOfWork.SaveChanges();

            busDTO._idBus = bus._idBus;

			return Created(new Uri(Request.RequestUri + "/" + bus._idBus), busDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var busInDataBase = _UnityOfWork.Bus.Get(id);
			if (busInDataBase == null)
				return NotFound();

			_UnityOfWork.Bus.Remove(busInDataBase);
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