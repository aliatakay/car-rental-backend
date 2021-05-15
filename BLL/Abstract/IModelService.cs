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
    }
}
