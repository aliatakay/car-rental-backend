using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
