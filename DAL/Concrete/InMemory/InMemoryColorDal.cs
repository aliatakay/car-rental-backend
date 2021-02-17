using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors = new List<Color>
        {
            new Color { ColorId = 1, ColorName = "Red"},
            new Color { ColorId = 2, ColorName = "Blue"},
            new Color { ColorId = 3, ColorName = "Black"},
            new Color { ColorId = 4, ColorName = "White"},
            new Color { ColorId = 5, ColorName = "Orange"},
            new Color { ColorId = 6, ColorName = "Dark Blue"}
        };

        public void Add(Color entity)
        {
            _colors.Add(entity);

        }

        public void Delete(Color entity)
        {
            _colors.Remove(_colors.SingleOrDefault(c => c.ColorId == entity.ColorId));

        }

        public Color Get(Expression<Func<Color, bool>> expr)
        {
            return _colors.SingleOrDefault(expr.Compile());

        }

        public List<Color> GetAll(Expression<Func<Color, bool>> expr = null)
        {
            return (expr == null)
                ? _colors
                : _colors.Where(expr.Compile()).ToList();
        }

        public void Update(Color entity)
        {
            Color color = _colors.SingleOrDefault(b => b.ColorId == entity.ColorId);

            color.ColorName = entity.ColorName;
        }
    }
}
