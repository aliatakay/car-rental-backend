using Core.Repository.EntityFramework;
using CarRental.Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarRental.Data.Concrete.EntityFramework
{
    public class EfCustomerRepository : EfEntityRepositoryBase<Customer, RentalManagementContext>, ICustomerRepository
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