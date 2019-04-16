using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarsInventory.Data
{

    public partial class CarsInventoryContext : DbContext
    {
        public CarsInventoryContext()
            : base("name=CarsInventoryContext")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
