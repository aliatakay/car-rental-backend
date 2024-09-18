using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace BLL.Abstract
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