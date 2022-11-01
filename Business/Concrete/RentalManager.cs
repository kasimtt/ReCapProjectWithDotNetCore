using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Added(Rental rental)
        {
            _rentalDal.Added(rental);
            return new SuccessResult(Messages.AddedRentalMessage); 
        }

        public IResult Deleted(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedRentalMessage);
        }

        public IDataResult<List<Rental>> getAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());  // mesaj eklemek sana kalmış ama bence gereksiz
        }

        public IDataResult<Rental> getById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));// mesaj eklemek sana kalmış
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
