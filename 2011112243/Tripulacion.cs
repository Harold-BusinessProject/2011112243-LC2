using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class Tripulacion : Empleado
    {
        public String estado { get; set; }
        public String horasTrab { get; set; }
        public TipoTripulacion _tipoTrip;
        public Tripulacion (TipoTripulacion TipoTrip){
            _tipoTrip = TipoTrip;
        }

        


            

            
    }
}
