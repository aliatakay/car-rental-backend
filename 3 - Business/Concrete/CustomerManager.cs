using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            //ValidationTool.Validate(new CustomerValidator(), customer);

            _customerRepository.Add(customer);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(c => c.Id == id), Messages.DataListed);

        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(c => c.UserId == userId), Messages.DataListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetAllAsDto()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerRepository.GetAllAsDto(), Messages.DataListed);
        }

        public IResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}