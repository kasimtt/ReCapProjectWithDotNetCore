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
            //BrandTest();

            // CarTest2();

            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User();
            user.FirstName = "kasim islam";
            user.LastName = "tatli";
            user.Password = "43434";
            user.Email = "kasimislamtatli@gmail.com";
            

            userManager.Add(user);

        }

        private static void CarTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetByPrince(100, 100000);
            foreach (var car in cars.Data)
            {
                Console.WriteLine(car.CarName + "==>" + car.DailyPrice + "\n");

            }
            Console.WriteLine(cars.Message);
        }

        private static void BrandTest()
        {
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
            var result = car.GetCarDetails();
           
            foreach (var car1 in car.GetCarDetails().Data)
            {
                Console.WriteLine("car name : " + car1.CarName + "\n" +
                                  "car brand: " + car1.BrandName + "\n" + 
                                  "car color: " + car1.ColorName + "\n" +
                                  "car daily price : " + car1.DailyPrice + "\n" + "\n");
            }
        }

    }
}
