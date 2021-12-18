namespace Car.Model.Product
{
    public class InsertProduct
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string FuelType { get; set; }
        public int Km { get; set; }
        public string CaseType { get; set; }
        public int EnginePower { get; set; }
        public int EngineCapacity { get; set; }
        public int Year { get; set; }
    }
}
