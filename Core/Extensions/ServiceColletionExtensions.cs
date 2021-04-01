using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceColletionExtensions
    {
        //Iservice Collection bizim aspnet uygulamımızın servis bagımllıklarımızı ekledıgımız ya da araya gırmesını ıstedıgımız servıslerı yazdıgımız yerdir.
        //burada polimorfizm uyguladık ICoreModule'den oluşan tum sınıfları alabilecek bir dizin oluşturduk imzada.
        //This kısmı neyi genişletmek istediğimizi gösteriyor.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicesCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicesCollection);
            }

            return ServiceTool.Create(servicesCollection);
        }
    }
}
