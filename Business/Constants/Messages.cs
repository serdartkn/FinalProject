using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        internal static readonly string CheckIfCategoryLimitExceded = "Kategori sayısı 15'i aştı";
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Ürünler Listelenemedi!";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductUpdated = "Ürün Güncellendi.";
        public static string ProductDeleted = "Ürün Silindi.";
        public static string ProductNotFound = "Silinecek Ürün Bulunamadı!";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 adet ürün olabilir.";
        public static string CheckIfProductOfNameExists = "Aynı isime sahip 2 ürün olamaz";


    }
}
