using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using ProjetoCallCode.Model;

namespace ProjetoCallCode.DAO
{
    class CallcenterEntities : DbContext
    {
        public CallcenterEntities(): base("CallcenterEntities"){ }

        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Cargo>().ToTable("cargos");

            base.OnModelCreating(modelBuilder);

        }
    }
}
