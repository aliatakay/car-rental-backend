using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IBrandService
    {
        Brand GetById(int id);
        List<Brand> GetAll();
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);

    }
}
