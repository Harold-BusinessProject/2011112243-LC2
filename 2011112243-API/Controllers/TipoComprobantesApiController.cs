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
	public class TipoComprobantesApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public TipoComprobantesApiController()
		{

		}

		public TipoComprobantesApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var TipoComprobantes = _UnityOfWork.TipoComprobante.GetAll();

			if (TipoComprobantes == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var TipoComprobanteDTO = new List<TipoComprobanteDTO>();

			foreach (var tipoComprobante in TipoComprobantes)
            TipoComprobanteDTO.Add(Mapper.Map<TipoComprobante, TipoComprobanteDTO>(tipoComprobante));

			return Ok(TipoComprobanteDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var tipoComprobante = _UnityOfWork.TipoComprobante.Get(id);

			if (tipoComprobante == null)
				return NotFound();

			return Ok(Mapper.Map<TipoComprobante, TipoComprobanteDTO>(tipoComprobante));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, TipoComprobanteDTO tipoComprobanteDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var tipoComprobanteInPersistence = _UnityOfWork.TipoComprobante.Get(id);
			if (tipoComprobanteInPersistence == null)
				return NotFound();

			Mapper.Map<TipoComprobanteDTO, TipoComprobante>(tipoComprobanteDTO, tipoComprobanteInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(tipoComprobanteDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(TipoComprobanteDTO tipoComprobanteDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var tipoComprobante = Mapper.Map<TipoComprobanteDTO, TipoComprobante>(tipoComprobanteDTO);

			_UnityOfWork.TipoComprobante.Add(tipoComprobante);
			_UnityOfWork.SaveChanges();

            tipoComprobanteDTO.TipodeComprobante = tipoComprobante.TipodeComprobante;

			return Created(new Uri(Request.RequestUri + "/" + tipoComprobante.TipodeComprobante), tipoComprobanteDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var tipoComprobanteInDataBase = _UnityOfWork.TipoComprobante.Get(id);
			if (tipoComprobanteInDataBase == null)
				return NotFound();

			_UnityOfWork.TipoComprobante.Remove(tipoComprobanteInDataBase);
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