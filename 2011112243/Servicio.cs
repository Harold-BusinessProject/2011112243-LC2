using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public abstract class Servicio
    {
        public String idServicio { get; set; }
        public String tipoServicio { get; set; }
        public String Origen { get; set; }
   
    public abstract void SeleccionarServicio();
} }
