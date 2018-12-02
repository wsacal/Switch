using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.Infra.CrossCutting.Logging;
using Switch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwitchAPP
{
    class Program
    {
        static void Main(string[] args)
        {

            Usuario usuario1;
            Usuario usuario2;
            Usuario usuario3;
            Usuario usuario4;
            Usuario usuario5;

            Usuario CriarUsuario(string nome)
            {
                return new Usuario()
                {
                    Nome = nome,
                    SobreNome = "joaquina",
                    Email = "wsacal@gmail.com",
                    Senha = "teste",
                    DataNascimento = DateTime.Now,
                    Sexo = Switch.Domain.Enums.SexoEnum.Femenino,
                    UrlFoto = @"c:\fotos"
                };                         
                
            }

            usuario1 = CriarUsuario("Usuario1");
            usuario2 = CriarUsuario("Usuario2");
            usuario3 = CriarUsuario("Usuario3");
            usuario4 = CriarUsuario("Usuario4");
            usuario5 = CriarUsuario("Usuario5");



            List<Usuario> usuarios = new List<Usuario>() { usuario1, usuario2, usuario3, usuario4 };
          
                  
            var optionBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionBuilder.UseLazyLoadingProxies();
            //optionBuilder.UseMySql("Server=localhost; userid=root; password=sacal;database=SwitchDB;", m => m.MigrationsAssembly("Switch.Infra.Data"));
            optionBuilder.UseMySql("Server=localhost; userid=newuser2; password=123;database=SwitchDB;", m => m.MigrationsAssembly("Switch.Infra.Data").MaxBatchSize(100));


            try
            {
                using (var dbcontext = new SwitchContext(optionBuilder.Options))
                {
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //dbcontext.Usuarios.Add(usuario1);
                    //dbcontext.Usuarios.Add(usuario2);
                    //dbcontext.Usuarios.Add(usuario3);
                    //dbcontext.Usuarios.Add(usuario4);
                    //dbcontext.Usuarios.AddRange(usuario1, usuario2, usuario3, usuario4);
                    //dbcontext.Usuarios.Add(usuario5);
                    //dbcontext.Usuarios.AddRange(usuarios);

                    //dbcontext.SaveChanges();

                    //var resultado = dbcontext.Usuarios.ToList();

                    //var resultado = dbcontext.Usuarios.Where(u => u.Nome == "Usuario1").ToList();

                    //foreach (var us in resultado)
                    //{


                    //}

                    var usuarioNovo = CriarUsuario("usuarioNovo1");
                    dbcontext.Usuarios.Add(usuarioNovo);
                    dbcontext.SaveChanges();

                    var usuarioRetrono = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuarioNovo1");

                    if (usuarioRetrono == null)
                    {
                        Console.WriteLine("Usuário não encontrado");
                    }


                    //Console.WriteLine("Nome do Usuario Criado = " + usuarioRetrono.Nome);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            //Console.WriteLine("Usuário salvo com sucesso!");
            Console.WriteLine("OK!");
            Console.ReadKey();
            
        }
    }
}
