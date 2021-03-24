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

        //Aþaðýdaki kod yukarýdaki haliyle varsayýlan olarak geliyor fakat bir startup a yazdýgýmýz kodlar yerine AutofacBusinessModule.cs
        //de bulunan kodlarýn geçerli olmasýný istediðimiz için sýrasýyla

        //1. Host.CreateDefaultBuilder(args)'dan sonra .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //Yani servis saðlayýcý olarak Autofac servis saðlayýcýsýný kullan diyoruz.
        //2. .ConfigureContainer<ContainerBuilder>(builder =>
        //{
        //   builder.RegisterModule(new AutofacBusinessModule());
        //})
        //Yani burada diyoruz ki 1. adýmda servis saðlayýcýyý kullan dedik ama servis saðlayýcýnýnda AutofacBusinessModule adýndaki
        //bu dosyasýný kullan.

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
