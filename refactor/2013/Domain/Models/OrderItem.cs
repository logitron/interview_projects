namespace Domain.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}