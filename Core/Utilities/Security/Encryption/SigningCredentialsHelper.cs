using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //oturum açma kimlik bilgileri anlamına gelir.(kullanıcı adı şifre vb.)
    //jwtlerin oluşturulabilmesi için anahtara ıhtıyacımız var 
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //hashing olarak security key kullan şifreleme olarakta sha512 kullan. 
            //securitykey degıskenı bızım appsettingde belirttiğimiz daha sonra securityhelperda simetrik hale getirdiğimiz keydir.
            //yani diyoruzki gelen tokenları bu key e ve bu algorıtmaya gore kontrol et.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
 