using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    //Bir kişinin jwt'den gelen claimlerini okumak için "claimsPrincipal"(jwt'ye gelen kişinin claimlerine ulaşmak için) .net'de olan classtır. 
    public static class ClaimsPrincipalExtensions
    {
        //Kişinin ilgiliclimtpye göre rollerini bulmak için yazılmış bir metottur.
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        //burası ise rolleri döndürüyor.
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
