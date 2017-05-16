using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
   public class Bus
    {
        public String _idBus { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String numAsientos { get; set; }
        public String TipoBus { get; set; }
        public Tripulacion _Tripulacion;


        public Bus(Tripulacion Tripulacion) {
            _Tripulacion = Tripulacion;
        
        }
    }
}
