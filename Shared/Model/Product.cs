namespace Shared.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public double Price  { get; set; }
        public string Category { get; set; } = null!;
        public int Quantity { get; set; }
        public string Location { get; set; } = null!;
    }
}
