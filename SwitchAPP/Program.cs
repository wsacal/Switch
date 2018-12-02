using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.Infra.CrossCutting.Logging;
using Switch.Infra.Data.Context;
using System;

namespace SwitchAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario()
            {
                Nome = "Maria",
                SobreNome = "joaquina",
                Email ="wsacal@gmail.com",
                Senha = "teste",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Enums.SexoEnum.Femenino,
                UrlFoto = @"c:\fotos"
            };

            var optionBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionBuilder.UseLazyLoadingProxies();
            optionBuilder.UseMySql("Server=localhost; userid=root; password=sacal;database=SwitchDB;", m => m.MigrationsAssembly("Switch.Infra.Data"));


            try
            {
                using (var dbcontext = new SwitchContext(optionBuilder.Options))
                {
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());
                    dbcontext.Usuarios.Add(usuario);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            Console.WriteLine("Usuário salvo com sucesso!");
            Console.ReadKey();
            
        }
    }
}
