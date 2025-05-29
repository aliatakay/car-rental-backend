using CarRental.Data.Contracts.DTOs;
using CarRental.Data.Contracts.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetByUserId(int userId);
        IDataResult<List<CustomerDetailDto>> GetAllAsDto();
    }
}