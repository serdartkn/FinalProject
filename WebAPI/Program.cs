using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>();
        //    });

        //A�a��daki kod yukar�daki haliyle varsay�lan olarak geliyor fakat bir startup a yazd�g�m�z kodlar yerine AutofacBusinessModule.cs
        //de bulunan kodlar�n ge�erli olmas�n� istedi�imiz i�in s�ras�yla

        //1. Host.CreateDefaultBuilder(args)'dan sonra .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //Yani servis sa�lay�c� olarak Autofac servis sa�lay�c�s�n� kullan diyoruz.
        //2. .ConfigureContainer<ContainerBuilder>(builder =>
        //{
        //   builder.RegisterModule(new AutofacBusinessModule());
        //})
        //Yani burada diyoruz ki 1. ad�mda servis sa�lay�c�y� kullan dedik ama servis sa�lay�c�n�nda AutofacBusinessModule ad�ndaki
        //bu dosyas�n� kullan.

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
