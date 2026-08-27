namespace AutoMapperSample.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string InternalCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
