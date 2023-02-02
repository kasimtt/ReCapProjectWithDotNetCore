using Business.Abstract;
using Business.Aspects.Autofact;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
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

        [ValidationAspect(typeof(CarValidator))] 
       // [SecuredOperation("car.list")] --> veri tabanına eklenicek...
        public IResult Added(Car car)
        {
            _carDal.Added(car);
            return new SuccessResult(Messages.AddedCarMessage);
        }

        public IResult Deleted(Car car)
        {
            //daha sonra silme durumuları özelliştirilicek

            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintananceTime);
            }
            //ilgili secmeler yapılır
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ListedCarMessage);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            var cars = _carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(cars);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.CarId == carId));
        }

        public IDataResult<List<Car>> GetByPrince(decimal min, decimal max)
        {
            var cars= _carDal.GetAll(p => p.DailyPrice <= max && p.DailyPrice >= min);
            if(cars.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(cars,Messages.ElementNotFount);
            }
            return new SuccessDataResult<List<Car>>(cars,Messages.ElementFound);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.getCarDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId)
        {
            var cars = _carDal.getCarDetailsByBrand(brandId);
            return new SuccessDataResult<List<CarDetailsDto>>(cars);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColor(int colorId)
        {
            var cars = _carDal.getCarDetailsByColor(colorId);
            return new SuccessDataResult<List<CarDetailsDto>>(cars);
        }
    }
}
