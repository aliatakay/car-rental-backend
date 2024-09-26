using Core.Repository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Data.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetAllAsDto(Expression<Func<Customer, bool>> expr = null);
    }
}