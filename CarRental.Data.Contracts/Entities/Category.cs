﻿using Core.Entities;

namespace CarRental.Data.Contracts.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}