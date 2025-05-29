using Core.Entities;

namespace CarRental.Data.Contracts.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}