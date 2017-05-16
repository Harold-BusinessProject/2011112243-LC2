using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2011112243;



namespace _2011112243
    {
    public class EmpTransporteDbContext : DbContext
    {
        public DbSet<_2011112243.Venta> Venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VentaConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
