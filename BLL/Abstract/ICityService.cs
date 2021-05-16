using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
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
