using Core.Entities;

namespace CarRental.Data.Contracts.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
    }
}