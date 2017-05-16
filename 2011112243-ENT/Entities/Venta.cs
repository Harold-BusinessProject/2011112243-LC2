using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
   public class Venta
    {
        public String idVenta { get; set; }
        public double Costo { get; set; }
        public Administrativo _Administrativo;
        public Servicio _Servicio;
        public Cliente _Cliente;
        public TipoPago _TipoPago;
        public TipoComprobante _tipoComprobante;

        public Venta(Servicio Servicio, Administrativo Administrativo, Cliente Cliente, TipoPago TipoPago, TipoComprobante TipoComprobante  ) {
            _Administrativo = Administrativo;
            _Servicio = Servicio;
            _Cliente = Cliente;
            _TipoPago = TipoPago;
            _tipoComprobante = TipoComprobante;

        }

       

    }
}
