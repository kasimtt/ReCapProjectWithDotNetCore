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
           
            Car car1 = new Car();

            car1.BrandId = 3;
            car1.CarId = 6;
            car1.CarName = "A656U";
            car1.ColorId = 3;
            car1.DailyPrice = 0;
            car1.Description = "sağlam";

            carManager.Added(car1);
            


            Console.ReadLine();
        }
    }
}
