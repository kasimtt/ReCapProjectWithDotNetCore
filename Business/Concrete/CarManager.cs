using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) // ilgili araç veritabanını secer.
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            //ilgili secmeler yapılır
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }
    }
}
