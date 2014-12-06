using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public long id { get; set; }
        public IList<OrderItem> items { get; set; }

        public Order()
        {
            items = new List<OrderItem>();
        }
    }
}