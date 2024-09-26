using Core.Repository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Data.Abstract
{
    public interface ICarRepository : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllAsDto(Expression<Func<CarDetailDto, bool>> expr = null);
    }
}