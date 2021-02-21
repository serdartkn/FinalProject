using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CategoryTest();
            //ProductTest();
            ProductManager productmanager = new ProductManager(new EfProductDal());
            foreach (var product in productmanager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productmanager = new ProductManager(new EfProductDal());

            //foreach (var p in productmanager.GetAll())
            //{
            //    Console.WriteLine(p.ProductName);
            //}

            //productmanager.GetAllByCagetoryId(2);
            //productmanager.GetAllByUnitPrice(20,35);
        }
    }
}
