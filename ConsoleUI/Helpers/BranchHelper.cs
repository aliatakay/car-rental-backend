using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using System;

namespace ConsoleUI.Helpers
{
    public static class BranchHelper
    {
        public static void Print()
        {
            BranchManager branchManager = new BranchManager(new EfBranchDal());

            var result = branchManager.GetAll();

            foreach (var branch in result.Data)
            {
                Console.WriteLine($"Id: {branch.Id}");
                Console.WriteLine($"City Id: {branch.CityId}");
                Console.WriteLine($"Address: {branch.Address}");
            }
        }
    }
}