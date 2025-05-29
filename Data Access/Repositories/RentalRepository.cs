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
    public class RentalRepository : EntityRepositoryBase<Rental, RentalManagementContext>, IRentalRepository
    {
        public List<RentalDetailDto> GetAllAsDto(Expression<Func<Rental, bool>> expr = null)
        {
            using (RentalManagementContext context = new RentalManagementContext())
            {
                var result = from brand in context.Brands
                             join car in context.Cars
                             on brand.Id equals car.Id
                             join rental in context.Rentals
                             on car.Id equals rental.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rental.Id,
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}