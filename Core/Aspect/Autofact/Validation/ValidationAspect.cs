using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofact.Validation
{
        public class ValidationAspect : MethodInterception
        {
            private Type _validatorType;
            //VALİDATOR TYPE İSTİYOR YANİ MANAGER DE [VALİDATİONASPECT(TYPEOF(PRODUCTVALİDATOR))]
            public ValidationAspect(Type validatorType)//burası attibute ve attrıbutelra tip(nesne) bu şekilde verilir.
            {
                if (!typeof(IValidator).IsAssignableFrom(validatorType)/*bu Is kısmi dıyor ki verilen tip atanabiliyor mu?*/)//EĞER GÖNDERİLEN VALİDATOR ıVALIDATOR DEGILSE HATA VER DİYORZ 
                {
                    throw new System.Exception("Bu bir doğrulama sınıfı değil.");
                }

                _validatorType = validatorType;//burası hata alınmadıgı taktırde productvalidator dur
            }
            protected override void OnBefore(IInvocation invocation)//nurada yapılan ıslemler ıse
            {
                var validator = (IValidator)Activator.CreateInstance(_validatorType);//productvalidatorun ınstancesını olustur
            //çalışma anında bir şeyi newlemek ıcın activator.createınstance kullanılır.
                var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidator gel baseclassına gir orada da git base clasın jeneric argümanın 0.sını yakala (yani product)
            //burası ıse productvalidatorun dogrulayacağı nesneyi (product) kontrol ediyor
                var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //burada diyoruz ki metodun (add) argümanlarını gez(product) eğer oradaki bir tür benim entitytype(product)a eşitse
            //onları ver.
                foreach (var entity in entities)//(productname vd)
                {
                    ValidationTool.Validate(validator, entity);
                }
            }
        }
}
