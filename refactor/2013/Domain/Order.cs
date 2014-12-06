using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public long Id { get; set; }
        public IList<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}