using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;
using Business.Constants;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CategoryTest();
            //ProductTest();


        }

        private static void CategoryTest()
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}
        }

        private static void ProductTest()
        {
            ProductManager productmanager = new ProductManager(new EfProductDal());

            //foreach (var p in productmanager.GetAll())
            //{
            //    Console.WriteLine(p.ProductName);
            //}

            //productmanager.GetAllByCagetoryId(2);
            //productmanager.GetAllByUnitPrice(20, 35);

            //var result = productmanager.GetProductDetails();
            //if (result.Success == true)
            //{
            //    foreach (var product in result.Data)
            //    {
            //        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }
    }
}
