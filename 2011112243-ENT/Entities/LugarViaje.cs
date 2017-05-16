using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class LugarViaje
    {
        public String idLugarViaje { get; set; }
        public String dep { get; set; }
        public String ciudad { get; set; }
        public String horaAprox { get; set; }
        public String fecha { get; set; }
        public TipoLugar _TipoLugar;


        public LugarViaje(TipoLugar TipoLugar) {
            _TipoLugar = TipoLugar;


        }

    }



}
