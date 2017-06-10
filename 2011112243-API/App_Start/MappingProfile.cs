using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _2011112243;

namespace MovieStore.WebAPI.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Bus, BusDTO>();
			CreateMap<BusDTO, Bus>();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<EmpleadoDTO, Empleado>();

            CreateMap<LugarViaje, LugarViajeDTO>();
            CreateMap<LugarViajeDTO, LugarViaje>();

            CreateMap<Servicio, ServicioDTO>();
            CreateMap<ServicioDTO, Servicio>();

            CreateMap<TipoComprobante, TipoComprobanteDTO>();
            CreateMap<TipoComprobanteDTO, TipoComprobante>();

            CreateMap<TipoPago, TipoPagoDTO>();
            CreateMap<TipoPagoDTO, TipoPago>();

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();
        }
	}
}