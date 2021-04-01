using Castle.DynamicProxy;
using Core.Aspect.Autofact.Performance;
using System;
using System.Linq;
using System.Reflection;
using static Core.Utilities.Interceptors.Class1;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {//VERDIGIMIZ CLASSIN, METOTLARIN VS ATTRIBUİTLERİNİ OKUYUP CALISMA SIRALARINA GORE LISTELEMEYE YARIYOR.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.AddRange(new PerformanceAspect);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
