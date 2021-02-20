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
