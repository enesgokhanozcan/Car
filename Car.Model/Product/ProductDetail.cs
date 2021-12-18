using System;

namespace Car.Model.Product
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string FuelType { get; set; }
        public int Km { get; set; }
        public string CaseType { get; set; }
        public int EnginePower { get; set; }
        public int EngineCapacity { get; set; }
        public int Year { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Udate { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }
        public string CategoryName { get; set; }
    }
}
