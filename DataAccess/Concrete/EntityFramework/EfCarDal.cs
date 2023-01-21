using Core.DataAccess.EnitityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarDatabaseContext>, ICarDal
    {
        //ekstra
        //. CarName, BrandName, ColorName, DailyPrice
        public List<CarDetailsDto> getCarDetails()
        {
            using(ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var result = from C in context.Cars
                             join B in context.Brands on
                             C.BrandId equals B.BrandId
                             join Co in context.Colors on
                             C.ColorId equals Co.ColorId
                             select new CarDetailsDto()
                             {
                                 BrandName = B.BrandName,
                                 CarName = C.CarName,
                                 ColorName = Co.ColorName,
                                 DailyPrice = C.DailyPrice
                             };
                return result.ToList();      
            }
        }

        public List<CarDetailsDto> getCarDetailsByBrand(int brandId)
        {
           using(ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var result = from C in context.Cars
                             join B in context.Brands on
                             C.BrandId equals B.BrandId
                             join Co in context.Colors on
                             C.ColorId equals Co.ColorId
                             where brandId == C.BrandId
                             select new CarDetailsDto()
                             {
                                 BrandName = B.BrandName,
                                 CarName = C.CarName,
                                 ColorName = Co.ColorName,
                                 DailyPrice = C.DailyPrice
                             };
                return result.ToList();

            }
        }

        public List<CarDetailsDto> getCarDetailsByColor(int colorId)
        {
            using(ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var result = from C in context.Cars
                             join B in context.Brands on
                             C.BrandId equals B.BrandId
                             join Co in context.Colors on
                             C.ColorId equals Co.ColorId
                             where colorId == C.ColorId
                             select new CarDetailsDto()
                             {
                                 BrandName = B.BrandName,
                                 CarName = C.CarName,
                                 ColorName = Co.ColorName,
                                 DailyPrice = C.DailyPrice
                             };
                return result.ToList();

            }
        }
    }
}
