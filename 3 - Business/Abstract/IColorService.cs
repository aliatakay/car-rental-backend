using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetById(int id);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<Color> GetByName(string name);
    }
}