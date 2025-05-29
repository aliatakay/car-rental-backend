using CarRental.Data.Contracts.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<Category> GetByName(string name);
    }
}