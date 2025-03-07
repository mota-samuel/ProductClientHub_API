namespace ProductClientHub_API.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public Guid ClientId { get; set; }
    }
}
