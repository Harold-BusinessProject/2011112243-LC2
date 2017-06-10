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
	public class EmpleadosApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public EmpleadosApiController()
		{

		}

		public EmpleadosApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var Empleados = _UnityOfWork.Empleado.GetAll();

			if (Empleados == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var EmpleadoDTO = new List<EmpleadoDTO>();

			foreach (var empleado in Empleados)
            EmpleadoDTO.Add(Mapper.Map<Empleado, EmpleadoDTO>(empleado));

			return Ok(EmpleadoDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var empleado = _UnityOfWork.Empleado.Get(id);

			if (empleado == null)
				return NotFound();

			return Ok(Mapper.Map<Empleado, EmpleadoDTO>(empleado));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, EmpleadoDTO empleadoDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var empleadoInPersistence = _UnityOfWork.Empleado.Get(id);
			if (empleadoInPersistence == null)
				return NotFound();

			Mapper.Map<EmpleadoDTO, Empleado>(empleadoDTO, empleadoInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(empleadoDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(EmpleadoDTO empleadoDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var empleado = Mapper.Map<EmpleadoDTO, Empleado>(empleadoDTO);

			_UnityOfWork.Empleado.Add(empleado);
			_UnityOfWork.SaveChanges();

            empleadoDTO.idEmp = empleado.idEmp;

			return Created(new Uri(Request.RequestUri + "/" + empleado.idEmp), empleadoDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var empleadoInDataBase = _UnityOfWork.Empleado.Get(id);
			if (empleadoInDataBase == null)
				return NotFound();

			_UnityOfWork.Empleado.Remove(empleadoInDataBase);
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