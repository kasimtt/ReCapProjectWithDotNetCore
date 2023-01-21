using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1,BrandId = 1, ColorId = 1, DailyPrice = 600, ModelYear = 2021, Description = "temiz araç"},
                new Car{CarId = 2,BrandId = 1, ColorId = 2, DailyPrice = 300, ModelYear = 2008, Description = "orta temizlikte araç"},
                new Car{CarId = 3,BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2014, Description = "temiz araç"},
                new Car{CarId = 4,BrandId = 3, ColorId = 3, DailyPrice = 100, ModelYear = 2000, Description = "Düşük segment araç"},
                new Car{CarId = 5,BrandId = 4, ColorId = 4, DailyPrice = 1000, ModelYear = 2022, Description = "Lüks araç"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Added(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDeleted = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDeleted);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            List<Car> brandCars = _cars.Where(p => p.BrandId == brandId).ToList();
            return brandCars;
        }

        public Car GetById(int carId)
        {
            Car takenCar = _cars.SingleOrDefault(p => p.CarId == carId);
            return takenCar;
        }

        public List<CarDetailsDto> getCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> getCarDetailsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> getCarDetailsByColor(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        
    }
}
