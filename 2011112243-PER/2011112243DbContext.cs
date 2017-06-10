
using _2011112243;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2011112243
    {
    public class EmpTransporteDbContext : DbContext
    {
        public DbSet<_2011112243.Venta> Venta { get; set; }
        public DbSet<_2011112243.Bus> Bus { get; set; }
        public DbSet<_2011112243.Cliente> Cliente { get; set; }
        
        public DbSet<_2011112243.LugarViaje> LugarViaje { get; set; }
        public DbSet<_2011112243.TipoComprobante> TipoComprobante { get; set; }
        public DbSet<_2011112243.TipoPago> TipoPago { get; set; }
      
        
        public DbSet<_2011112243.Servicio> Servicio { get; set; }
        public DbSet<_2011112243.Empleado> Empleado { get; set; }

        public EmpTransporteDbContext() : base("EmpTransporte")
		{

        }











        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VentaConfiguration());
            modelBuilder.Configurations.Add(new BusConfiguration());

            modelBuilder.Configurations.Add(new ClienteConfiguration());

          

     
            modelBuilder.Configurations.Add(new LugarViajeConfiguration());

       
            modelBuilder.Configurations.Add(new ServicioConfiguration());

            modelBuilder.Configurations.Add(new TipoComprobanteConfiguration());

     
            modelBuilder.Configurations.Add(new TipoPagoConfiguration());

            

           
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
