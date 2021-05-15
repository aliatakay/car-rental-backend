using Core.DAL.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EntityFramework
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch, RentalManagementContext>, IBranchDal
    {
    }
}
