using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    // şifrelemee olan sıstemlerde her seyı byte[] formatında vermemız gerekıyor. basit bir stringle key olusuramayız 
    // stringleri jwtlerin anlayacagı bır hale getırmemız gerekıyor. yani bu class appsettingdeki keyi byte formatına dönüştürüyor.
    public class SecurityKeyHelper
    {
        //buradaki securitykey appseting dosyasındakıdir.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //keyler asimetrik ve simetrik olarak 2 ye ayrılır. biz simetrik kullanacağız. 
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
