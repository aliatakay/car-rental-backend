using CarRental.Data.Contracts.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface ICityService
    {
        IDataResult<City> GetById(int id);
        IDataResult<List<City>> GetAll();
        IResult Add(City city);
        IResult Update(City city);
        IResult Delete(City city);
        IDataResult<City> GetByName(string name);
    }
}