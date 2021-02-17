using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands = new List<Brand>
        {
            new Brand { BrandId = 1, BrandName = "BMW"},
            new Brand { BrandId = 2, BrandName = "Audi"},
            new Brand { BrandId = 3, BrandName = "Ford"},
            new Brand { BrandId = 4, BrandName = "Fiat"},
            new Brand { BrandId = 5, BrandName = "Tesla"},
            new Brand { BrandId = 6, BrandName = "Mercedes"}
        };

        public void Add(Brand entity)
        {
            _brands.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _brands.Remove(_brands.SingleOrDefault(b => b.BrandId == entity.BrandId));
        }

        public Brand Get(Expression<Func<Brand, bool>> expr)
        {
            return _brands.SingleOrDefault(expr.Compile());
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> expr = null)
        {
            return (expr == null)
                ? _brands
                : _brands.Where(expr.Compile()).ToList();
        }

        public void Update(Brand entity)
        {
            Brand brand = _brands.SingleOrDefault(b => b.BrandId == entity.BrandId);

            brand.BrandName = entity.BrandName;
        }
    }
}
