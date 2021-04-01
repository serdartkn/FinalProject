using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofact.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        //cache duration default değeri 60dakikadır.
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }


        public override void Intercept(IInvocation invocation)
        {
            //burada yazan invocation.Method.ReflectedType.FullName kodu bu metodu calıstırdıgımız yerdekı  namespace ve classın ısmını bıze verır.
            //invocation.Method.Name kodu ise metodun adını bize verir.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //burası ise metodun parametlerinin değerini listeler.
            var arguments = invocation.Arguments.ToList();
            //burası ise methodnameden elde ettıgımız bılgıler ile argumentsden elde edilen listeyi alır birleştirir.
            //x? boş olabilir demişizi ?? ise boş degılse strınge donustur ekle boş ise null yaz anlamında.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //olusturdugumuz bu key i Isadd e veriyourz bakıyor mı cache de var mı yok mu varsa
            if (_cacheManager.IsAdd(key))
            {
                //invocation.ReturnValue burası eger cache de varsa metodu hıc calıstırmadan geri dön demek, geri dönerkende geri dönüş değeri olarak getten veri alarak dön
                //(veri zaten cache de var dbye gitmiyor)
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //burası ise metodu calıstır devam ettır demek (veritabanına gider cachede olmayan datayı alır.)
            invocation.Proceed();
            //burada ise keyi, keyin valuesunu(valueyi metodun donusdegerıne atıyoruz.) ve süreyi add metoduna atıyoruz.
            //(invocation.ReturnValue) ile ekrana bilggiler gelıyor.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
