using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //bu classta ise token kontrolü yapılacak
    public class AccessToken
    {
        //Token - jwToken değerimizdir. kullanıcı kullanı adı sıfrre gırınce token vereceğiz ve ne zaman sonlanacagı bılgısını verecgız.
        public string Token { get; set; }
        //Token bitiş zamanı
        public DateTime Expiration { get; set; }
    }
}
