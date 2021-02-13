using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productmanager = new ProductManager(new InMemoryProductdal());

            foreach (var p in productmanager.GetAll())
            {
                Console.WriteLine(p.ProductName);
            }

        }
    }
}
