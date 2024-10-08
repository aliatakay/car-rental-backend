﻿using Core.Repository.EntityFramework;
using CarRental.Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarRental.Data.Concrete.EntityFramework
{
    public class EfCarRepository : EfEntityRepositoryBase<Car, RentalManagementContext>, ICarRepository
    {
        public List<CarDetailDto> GetAllAsDto(Expression<Func<CarDetailDto, bool>> expr = null)
        {
            using (RentalManagementContext context = new RentalManagementContext())
            {
                var result = from brand in context.Brands
                             join model in context.Models
                             on brand.Id equals model.BrandId
                             join car in context.Cars
                             on model.Id equals car.ModelId
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.Name,
                                 ModelName = model.Name,
                                 ColorName = color.Name,
                                 ModelYear = model.Year,
                                 DailyPrice = car.DailyPrice,
                                 IsAvailable = car.IsAvailable,
                                 Description = car.Description
                             };

                return result.ToList();
            }
        }
    }
}