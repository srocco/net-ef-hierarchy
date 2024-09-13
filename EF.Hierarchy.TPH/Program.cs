using EF.Hierarchy.TPH.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace EF.Hierarchy.TPH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IServiceScope scope = Setup(args);

            var dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();

            // Ejemplo: Crear la base de datos si no existe
            dbContext.Database.Migrate();

            Ejemplo(dbContext);
        }

        private static IServiceScope Setup(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                          .ConfigureServices((context, services) =>
                          {

                              var configuration = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .Build();

                              services.AddDbContext<EFContext>(options =>
                                  options.UseSqlServer("EFContext"));
                          })
                          .Build();
            var scope = host.Services.CreateScope();
            return scope;
        }

        private static void Ejemplo(EFContext context)
        {
            Alumno alumno = new Alumno
            {
                Nombre = "Juan",
                Apellido = "Perez",
                Curso = "Segundo"
            };
            context.Alumnos.Add(alumno);


            Profesor profesor = new Profesor
            {
                Nombre = "Martín",
                Apellido = "Lopez",
                Asignatura = ".NET"
            };

            context.Profesores.Add(profesor);

            //Persona persona = new Persona
            //{
            //    Nombre = "Pedro",
            //    Apellido = "Gonzales"
            //};

            //context.Personas.Add(persona);

            context.SaveChanges();

            var alumnoExistente = context.Alumnos.FirstOrDefault();
            var profesorExistente = context.Profesores.FirstOrDefault();
            var personaExistente = context.Personas.FirstOrDefault();

            if (alumnoExistente != null)
            {
                Console.WriteLine(string.Format("Alumno {0}", alumnoExistente.Nombre));
            } 
            if (profesorExistente != null)
            {
                Console.WriteLine(string.Format("Profesor {0}", profesorExistente.Nombre));
            }
            if (personaExistente != null)
            {
                Console.WriteLine(string.Format("Persona {0}", personaExistente.Nombre));
            }
        }
    }
}
