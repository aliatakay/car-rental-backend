using BLL.Concrete;
using ConsoleUI.Helpers;
using DAL.Concrete.EntityFramework;
using DAL.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalHelper.Print();
        }
    }
}
