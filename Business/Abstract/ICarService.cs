using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        // voidleri IResult yapalım diğerlerini de IResultData<T>
        IDataResult<List<Car>> GetAll(); 
        IDataResult<Car> GetById(int carId); 
        IDataResult<List<Car>> GetByPrince(decimal min, decimal mix); 
        IResult Added(Car car); 
        IResult Deleted(Car car); 
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByColor(int colorId);
    }

}
