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
	public class ClientesApiController : ApiController
	{
		private EmpTransporteDbContext db = new EmpTransporteDbContext();
		private readonly IUnityOfWork _UnityOfWork;

		public ClientesApiController()
		{

		}

		public ClientesApiController(IUnityOfWork unityOfWork)
		{
			_UnityOfWork = unityOfWork;
		}

	
		[HttpGet]
		public IHttpActionResult Get()
		{
			
			var Clientes = _UnityOfWork.Cliente.GetAll();

			if (Clientes == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			var clienteDTO = new List<ClienteDTO>();

			foreach (var cliente in Clientes)
            clienteDTO.Add(Mapper.Map<Cliente, ClienteDTO>(cliente));

			return Ok(clienteDTO);
		}

		
		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var cliente = _UnityOfWork.Cliente.Get(id);

			if (cliente == null)
				return NotFound();

			return Ok(Mapper.Map<Cliente, ClienteDTO>(cliente));
		}

		
		[HttpPut]
		public IHttpActionResult Update(int id, ClienteDTO clienteDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var clienteInPersistence = _UnityOfWork.Cliente.Get(id);
			if (clienteInPersistence == null)
				return NotFound();

			Mapper.Map<ClienteDTO, Cliente>(clienteDTO, clienteInPersistence);

			_UnityOfWork.SaveChanges();

			return Ok(clienteDTO);
		}


		
		[HttpPost]
		public IHttpActionResult Create(ClienteDTO clienteDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var cliente = Mapper.Map<ClienteDTO, Cliente>(clienteDTO);

			_UnityOfWork.Cliente.Add(cliente);
			_UnityOfWork.SaveChanges();

            clienteDTO.idCliente = cliente.idCliente;

			return Created(new Uri(Request.RequestUri + "/" + cliente), clienteDTO);
		}

	
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var clienteInDataBase = _UnityOfWork.Cliente.Get(id);
			if (clienteInDataBase == null)
				return NotFound();

			_UnityOfWork.Cliente.Remove(clienteInDataBase);
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