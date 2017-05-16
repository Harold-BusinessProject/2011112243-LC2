using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    class Transporte : Servicio

    {
       
        public TipoViaje _TipoViaje;
        public Cliente _Cliente;
        public Bus _Bus;
        public LugarViaje _LugarViaje;
        public String TipoServicio { get; set; }
        public String nAsientos { get; set; }

        public Transporte(TipoViaje TipoViaje, Cliente Cliente, Bus Bus, LugarViaje LugarViaje) {
            _TipoViaje = TipoViaje;
            _Cliente = Cliente;
            _Bus = Bus;
            _LugarViaje = LugarViaje;

        }

        public override void SeleccionarServicio() {
            tipoServicio=TipoServicio; 
        }


    }
}
