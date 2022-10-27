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
            //CarTest();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brands = brandManager.getBrandAll();

            foreach (var brand in brands)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.ReadLine();
        }

        private static void CarTest()
        {
            CarManager car = new CarManager(new EfCarDal());

            foreach (var car1 in car.GetCarDetails())
            {
                Console.WriteLine("car name : " + car1.CarName + "\n" +
                                  "car brand: " + car1.BrandName + "\n" + 
                                  "car color: " + car1.ColorName + "\n" +
                                  "car daily price : " + car1.DailyPrice + "\n" + "\n");
            }
        }

    }
}
