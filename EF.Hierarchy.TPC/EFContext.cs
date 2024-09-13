using EF.Hierarchy.TPC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.Hierarchy.TPC
{
    internal class EFContext: DbContext
    {
       // public DbSet<Persona> Personas{ get; set; }

        public DbSet<Alumno> Alumnos{ get; set; }

        public DbSet<Profesor> Profesores{ get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("EFContext"));


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().UseTpcMappingStrategy();
        }
    }
}
