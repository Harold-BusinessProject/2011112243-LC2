using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class TipoComprobante
    {
        public String TipodeComprobante { get; set; }
        public List<Venta> Venta { get; set; }

        public TipoComprobante()
        {
            Venta = new List<Venta>();
        }
    }
}
