using System.Linq;
using Core.DAL.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalManagementContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentalManagementContext context = new RentalManagementContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             select new CustomerDetailDto
                             {
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
