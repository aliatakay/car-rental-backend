using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace BLL.Abstract
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