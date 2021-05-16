using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetById(int id);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<Brand> GetByName(string name);

    }
}
