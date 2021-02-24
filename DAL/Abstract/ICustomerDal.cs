﻿using Core.DAL;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetails();
    }
}