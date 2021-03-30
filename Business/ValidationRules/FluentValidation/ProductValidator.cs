using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {// BURADA FLUENTVALİDATİON KULLANARAK NESNELERİMİZE KURALLAR KOYABİLİYORUZ BU KURALLARI FLUENT İLE YAPICAĞIMIZ İÇİN KLASÖRLEME YAPTIK
        //VE HER NESNEMİZ İÇİN AYRI AYRI OLUŞTURUYORUZ. BU KURALLARA ERİŞMEK İÇİNSE HER NESNEİN MANAGERİNDE BURAYI NEWLEMEK YERİNE GENERİC
        //BİR YAPI KODLUYORUZ. >> CORE > CROSSCUTTİNGCONCERNS > VALİDATİON > FLUENTVALİDATİON > NESNELERE AİT .CS (PRODUCTVALİDATOR.CS)
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //RuleFor(p => p.ProductName).Must(StartWithA);
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
