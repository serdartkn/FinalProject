using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{//STARTUP'DA YAZDIĞIMIIZ KODLARI AUTOFAC İLE YAPMAK İSTEDİĞİMİZ İÇİN GEREKLİ KLASÖRLEME İŞLEMLERİNİ YAPTIKTAN SONRA BU İSİMDE BİR CLASS AÇTIK
    //VE CLASS İÇİNE AŞAĞIDA YILDIZLARA KADAR OLAN KODLARI YAZDIK.
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
          //******************************************************************************//
          //AAĞIDAKİ KOD İNTERCEPTERLERI DEVREYE SOKUYOR
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
