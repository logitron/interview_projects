namespace MVC.Models.Order
{
    public class OrderItemModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
    }
}