using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{

    /*ImemoryCache'de get,remove gibi metotlar olmasına ragmen bız bu metotları memorrycachemanager'de  hemen ahemen aynı 
    isime sahip metotlar olustrup burada cagırmamızın nedenı başka bir cachemanager sisteminde patlamamak ıcındır.
    memorycachemanager olusturup ıcındekı metotlara mıcrosoft cache metotlarını cagırmak adapter patterndir.
    (adaptasyon deseni)(yani var olan bir sistemi kendı sıstemımıze göre ayarladık.)
    IMemoryCache bir microsoft ürünüdür. Alternatif olarak redis kullanılabilir.*/
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            //TimeSpan zaman aralığı demek. TimeSpan'a Duration'da bulunan dakika kadar dakika ekle.
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            // out _ değer dondurmuyor.
            return _memoryCache.TryGetValue(key, out _);
        }

        public void RemoveByPattern(string pattern)
        {
            //bu kodlar verdiğimiz patterna göre silme işlemi yapaqcaktır.
            //çalışma anında reflection sayesinde silmeye yarar.
             
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }

        public void Romove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
