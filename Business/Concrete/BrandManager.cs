using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal) // secilen herhangi bi veri tabanına göre işlem yapar
        {
            this.brandDal = brandDal;
        }

        public List<Brand> getBrandAll()
        {
            return brandDal.GetAll();
        }
    }
}
