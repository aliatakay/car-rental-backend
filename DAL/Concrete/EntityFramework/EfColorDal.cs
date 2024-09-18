using Core.DAL.EntityFramework;
using DAL.Abstract;
using Entities.Concrete;

namespace DAL.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RentalManagementContext>, IColorDal
    {

    }
}