using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class Administrativo : Empleado
    {
        public String  turno { get; set; }
        public List<Venta> Venta { get; set; }

    public Administrativo()
    {
        Venta = new List<Venta>();
    }
}}
