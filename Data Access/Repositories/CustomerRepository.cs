using Core.Repository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CarRental.Data.Contracts.DTOs;
using CarRental.Data.Contracts.Repositories;
using CarRental.Data.Contracts.Entities;

namespace CarRental.Data.Repositories
{
    public class CustomerRepository : EntityRepositoryBase<Customer, RentalManagementContext>, ICustomerRepository
    {
        public List<CustomerDetailDto> GetAllAsDto(Expression<Func<Customer, bool>> expr = null)
        {
            using (RentalManagementContext context = new RentalManagementContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.Id,
                                 UserId = c.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             };

                return result.ToList();
            }
        }
    }
}