using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class Encomienda : Servicio
    {
        public String peso { get; set; }
        public String dimensiones { get; set; }
        public LugarViaje _LugarViaje;
        public String nbultos { get; set; }
        public String TipoServicio {get; set;}
        public Bus _Bus;
    public Encomienda (LugarViaje LugarViaje, Bus Bus) {
            _LugarViaje = LugarViaje;
            _Bus._idBus = Bus._idBus;
        }
    public override void SeleccionarServicio()
    {
        tipoServicio = TipoServicio;
    }

        
}}
