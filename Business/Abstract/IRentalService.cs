using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Added(Rental rental); 
        IResult Deleted(Rental rental); 
        IResult Update(Rental rental); 
        IDataResult<List<Rental>> GetAll(); 
        IDataResult<Rental> GetById(int id);

        
    }
}
