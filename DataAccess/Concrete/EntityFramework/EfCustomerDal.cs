using Core.DataAccess.EnitityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCarDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> getCustomerDetails()
        {
            using (ReCarDatabaseContext context = new ReCarDatabaseContext())
            {
                var result = from C in context.Customers
                             join U in context.Users on
                             C.UserId equals U.UserId
                             select new CustomerDetailsDto()
                             {
                                 CompanyName = C.CompanyName,
                                 FirstName = U.FirstName,
                                 LastName = U.LastName,
                             };
                return result.ToList();

            }
        }
    }
}
