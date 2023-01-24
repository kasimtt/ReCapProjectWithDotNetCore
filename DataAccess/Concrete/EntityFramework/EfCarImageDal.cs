using Core.DataAccess.EnitityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarDatabaseContext>, IRentalDal
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCarDatabaseContext>, ICarImageDal
    {
       
    }
}
