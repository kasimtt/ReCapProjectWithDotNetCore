using Core.DataAccess.EnitityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCarDatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaim(User user)
        {
            //OperationClaim sınıfına ek OperationClaimDto sınıfı da oluşturulabilir.
            // şuan gerek duymadım ama gerekirse refactor yaparım
            using (var context = new ReCarDatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaim
                             where user.UserId == userOperationClaim.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
