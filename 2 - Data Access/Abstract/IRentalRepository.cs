using Core.Repository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Data.Abstract
{
    public interface IRentalRepository : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllAsDto(Expression<Func<Rental, bool>> expr = null);
    }
}