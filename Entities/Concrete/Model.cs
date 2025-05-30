﻿using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Model : IEntityWithGuidKey
    {
        public Guid Id { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
    }
}