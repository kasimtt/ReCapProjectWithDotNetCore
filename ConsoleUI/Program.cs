using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car a = carManager.GetById(1);
            Console.WriteLine(a.ModelYear);
            Console.WriteLine(a.CarName);
            Console.WriteLine(a.CarId);

            
        }
    }
}
