using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; // car databaselerinden uygun olan alınır. injection.
        public CarManager(ICarDal carDal) // ilgili araç veritabanını secer.
        {
            _carDal = carDal;
        }

        public void Added(Car car)
        {
            if (car.CarName.Length<2 || car.DailyPrice <=0 )
            {
                throw new Exception("hatali  giriş yaptınız");
            }
            _carDal.Added(car);
        }

        public List<Car> GetAll()
        {
            //ilgili secmeler yapılır
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(p=>p.CarId == carId);
        }

        public List<Car> GetByPrince(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice <= max && p.DailyPrice >= min);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.getCarDetails();
        }
    }
}
