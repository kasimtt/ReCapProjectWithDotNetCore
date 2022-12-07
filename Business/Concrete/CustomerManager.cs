using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Added(customer);

            return new SuccessResult(Messages.AddedCustomerMessage);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DeletedCustomerMessage);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.ListedCustomerMessage);

        }

        public IDataResult<Customer> GetById(int id)
        {

            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id), Messages.ElementFound);
        }

        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.getCustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.UpgatedCustomerMessage);
        }

    }
}
