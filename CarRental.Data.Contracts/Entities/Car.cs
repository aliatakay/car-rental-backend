using Core.Entities;

namespace CarRental.Data.Contracts.Entities
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
    }
}