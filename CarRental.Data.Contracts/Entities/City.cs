using Core.Entities;

namespace CarRental.Data.Contracts.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}