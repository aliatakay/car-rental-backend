using CarRental.Data.Contracts.DTOs;
using CarRental.Data.Contracts.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Data.Contracts.Repositories
{
    public interface IRentalRepository : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllAsDto(Expression<Func<Rental, bool>> expr = null);
    }
}