using Core.Entities;

namespace CarRental.Data.Contracts.Entities
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
    }
}