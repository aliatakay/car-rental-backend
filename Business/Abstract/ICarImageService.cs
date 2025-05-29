using CarRental.Data.Contracts.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}