using Core.Entities;
using System;

namespace CarRental.Data.Contracts.Entities
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}