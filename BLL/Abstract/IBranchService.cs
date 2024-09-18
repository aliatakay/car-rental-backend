﻿using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IBranchService
    {
        IDataResult<Branch> GetById(int id);
        IDataResult<List<Branch>> GetAll();
        IResult Add(Branch branch);
        IResult Update(Branch branch);
        IResult Delete(Branch branch);
        IDataResult<List<Branch>> GetAllByCityId(int cityId);
    }
}