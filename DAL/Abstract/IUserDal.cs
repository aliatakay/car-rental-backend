using Core.DAL;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
