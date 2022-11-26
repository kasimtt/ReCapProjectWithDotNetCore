using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) // secilen herhangi bi veri tabanına göre işlem yapar
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> getBrandAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }
    }
}
