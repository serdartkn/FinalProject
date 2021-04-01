using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //Burası tüm cache yöntemlerı ıcın uygun bır yapıdır. Farklı teknıkler kullanılacağı zaman ımplemente etmek yeterli.
        //Duration, cache'nin kalma süresi.
        //Key cachenin adıdır. mesela product.GetAll diyince oradaki bilgileri alıp belleğe atıcak
        //Bu generic yapı cacheden veri alırken tip almış olucak.
        T Get<T>(string key);
        //bu da yukarıdakinin object li hali
        object Get(string key);
        //Key kısmı misal bi metot adı, value keyden gelecek deger, duratıon ise degerin bellekte durma süresi 
        void Add(string key, object value, int duration);
        //bilgi cache'de var mı ?
        bool IsAdd(string key);
        //güncellenen, silinen vsbilgileri bellekten eski halini silmek için kullanıcaz.
        void Romove(string key);
        //burası ise parametleri metotlardan alınan cacheleri silecek zira hangi parametre aldıgını bilemeyiz. hangi ıd gibi
        void RemoveByPattern(string pattern);
    }
}
