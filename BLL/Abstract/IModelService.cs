using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IModelService
    {
        IDataResult<Model> GetById(int id);
        IDataResult<List<Model>> GetAll();
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
        IDataResult<List<Model>> GetAllByBrandId(int brandId);
        IDataResult<List<Model>> GetAllByCategoryId(int categoryId);
        IDataResult<Model> GetByName(string name);
        IDataResult<List<Model>> GetAllByYear(int year);
        IDataResult<List<Model>> GetAllByYearBetween(int minYear, int maxYear);
        IDataResult<List<Model>> GetAllByYearGreaterThanOrEqualTo(int year);
        IDataResult<List<Model>> GetAllByYearGreaterThan(int year);
        IDataResult<List<Model>> GetAllByYearLessThanOrEqualTo(int year);
        IDataResult<List<Model>> GetAllByYearLessThan(int year);
    }
}
