using CarRental.Data.Contracts.DTOs;
using CarRental.Data.Contracts.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Data.Contracts.Repositories
{
    public interface ICarRepository : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllAsDto(Expression<Func<CarDetailDto, bool>> expr = null);
    }
}