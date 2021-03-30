using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Verdiğimiz Password'e Hash Oluşturucak Aynı zamanda salting'de yapacak
        //biz bir password vericez hashli ve saltlı halleri ise out'a verilen değerler olarak dışarıya verilecek. (dışarıdan kasıt)
        //Bu hashleme işlemini
        public static void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordSalt)
        {
            //hmac değişkeni kriptografi sınıfında kullandıgımız class a denk geliyor. (SHA-512 kullanacağız)
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //hmac'in oluşturduğu key değerini salt a veriyoruz.
                passwordSalt = hmac.Key;
                //hmac'in computehash metoduna ise passwordümüzü veriyoruz. ve değeri passwordHash'a atıyoruz.
                //string passwordu, byte passwordhash a atayacagımız için string password'u byte'a dönüştürüp byte değerini alıyoruz.
                //Encoding.UTF8.GetBytes(password) - utf8 formatlı stringlerin byte değerini alır.
                passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }

        //Password Hashi Doğrulamamıza yarayan bir metottur.
        //Yukarkıdaki metot kullanıcı ğyelik oluştururken verilen sıfreyi hashler ve tuzlar. Bu metot ise kullanıcı sisteme tekrar giriş
        //yaptıgı zaman girdiği şifreyi alır ilk uyelik olusturdugun elde edılen passwordsalt yani hmac.key kullanılarak girilen şifreden
        //yeni bir hash değeri üretilir bu değer computedhash degıskenıne atılır ardından fondu yardımıyla önceki hash ile şimdiki hash
        //karşılaştırılır. dopruysa logın degılse game over!!
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
