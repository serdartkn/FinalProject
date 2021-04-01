using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.Aspect.Autofact.Performance
{
    //Bu aspect calıstırdıgımız metodun kac sanıyede calıstıgınız gosterır.
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        //bu timerdır (kronomometredir.)
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            // interval metodun calısmasını ongordugumuz suredir aspecti cagırınca [Performanceaspect(5)] yazarsak 5 sanıye olur
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        //attrıbuite olarak yazdıgımız metodun basında calısır. kronomometre calısır.
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        //burası ıse metotun bıtımınde aktıf olur ve onbeforeden ıtıbaren gecen sureyı hhesaplar ve ınterval olarak verdiğimiz süreden
        //büyükse bize uyarı verir. değilse kronometre durar.
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
