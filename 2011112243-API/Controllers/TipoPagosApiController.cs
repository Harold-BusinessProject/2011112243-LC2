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
	public class TipoPagosApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public TipoPagosApiController()
		{

		}

		public TipoPagosApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var TipoPagos = _UnityOfWork.TipoPago.GetAll();

			if (TipoPagos == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var TipoPagoDTO = new List<TipoPagoDTO>();

			foreach (var tipoPago in TipoPagos)
            TipoPagoDTO.Add(Mapper.Map<TipoPago, TipoPagoDTO>(tipoPago));

			return Ok(TipoPagoDTO);
		}


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tipoPago = _UnityOfWork.TipoPago.Get(id);

            if (tipoPago == null)
                return NotFound();

            return Ok(Mapper.Map<TipoPago, TipoPagoDTO>(tipoPago));

        }
		
		[HttpPut]
		public IHttpActionResult Update(int id, TipoPagoDTO tipoPagoDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var tipoPagoInPersistence = _UnityOfWork.TipoPago.Get(id);
			if (tipoPagoInPersistence == null)
				return NotFound();

			Mapper.Map<TipoPagoDTO, TipoPago>(tipoPagoDTO, tipoPagoInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(tipoPagoDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(TipoPagoDTO tipoPagoDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var tipoPago = Mapper.Map<TipoPagoDTO, TipoPago>(tipoPagoDTO);

			_UnityOfWork.TipoPago.Add(tipoPago);
			_UnityOfWork.SaveChanges();

        tipoPagoDTO.tipodePago = tipoPago.tipodePago;

			return Created(new Uri(Request.RequestUri + "/" + tipoPago.tipodePago), tipoPagoDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var tipoPagoInDataBase = _UnityOfWork.TipoPago.Get(id);
			if (tipoPagoInDataBase == null)
				return NotFound();

			_UnityOfWork.TipoPago.Remove(tipoPagoInDataBase);
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