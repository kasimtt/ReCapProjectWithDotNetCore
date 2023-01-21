﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //GetById, GetAll, Add, Update, Delete
        List<CarDetailsDto> getCarDetails();
        List<CarDetailsDto> getCarDetailsByBrand(int brandId);
        List<CarDetailsDto> getCarDetailsByColor(int colorId);
    }
}
