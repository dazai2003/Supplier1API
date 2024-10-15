namespace Supplier1API.DTO
{
    public class ReadProductDTO
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string? Description { get; set; }
    }
}
