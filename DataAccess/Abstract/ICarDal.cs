using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //GetById, GetAll, Add, Update, Delete

        List<Car> GetAll();
        Car GetById(int carId);
        List<Car> GetByBrandId(int brandId);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
