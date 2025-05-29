using Core.Entities;

namespace CarRental.Data.Contracts.Entities
{
    public class Model : IEntity
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
    }
}