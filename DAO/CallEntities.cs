using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Callcenter.Model;

namespace Callcenter.DAO
{
    class CallEntities : DbContext
    {
        public DbSet <Funcionario> Funcionarios { set; get; }
        public DbSet <Ausencia> Ausencias { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet <Departamento> Departamentos { get; set; }
        public DbSet <Escala> Escalas { get; set; }
        public DbSet <HoraExtra> HorasExtras { get; set; }
        public DbSet <Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ausencia>().ToTable("Ausencias");
            modelBuilder.Entity<Cargo>().ToTable("Cargos");
            modelBuilder.Entity<Departamento>().ToTable("Departamentos");
            modelBuilder.Entity<Escala>().ToTable("Escalas");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionarios");
            modelBuilder.Entity<HoraExtra>().ToTable("HorasExtras");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            base.OnModelCreating(modelBuilder);
        }
    }
}
