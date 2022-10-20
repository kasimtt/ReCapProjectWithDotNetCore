using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = carManager.GetByPrince(500,1000);

            foreach (var car in cars )
            {
                Console.WriteLine(car.CarName);
            }


            Console.ReadLine();
        }
    }
}
