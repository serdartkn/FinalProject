using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public partial class Class1
    {//BURADAKİ YAPI SAYESİNDE VOLİDATİON, CACHE, LOG GİBİ YAPILARI ATTRİBUITE YAPIP METOTLARIN BAŞINA VS KOYMAMIZI SAĞLIYOR.
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
        {
            public int Priority { get; set; }

            public virtual void Intercept(IInvocation invocation)
            {

            }
        }
    }
}
