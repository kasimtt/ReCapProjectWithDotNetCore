using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IResult Add(User user); 
        IResult Delete(User user); 
        IResult Update(User user);
        IDataResult<List<User>> GetAll(); 
        IDataResult<User> GetById(int id);
        IDataResult<List<OperationClaim>> GetClaim(User user);
        IDataResult<User> GetByEmail(string email);
    }
}
