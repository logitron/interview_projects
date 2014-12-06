using System.Collections.Generic;

namespace Domain
{
    public class OrderRepository
    {
        public IList<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>();                 
        }     

        public void save(Order order)
        {
            var order_count = orders.Count;
            order.id = order_count + 1;
            orders.Add(order);                 
        }

        public IList<Order> get_all()
        {
            return orders;
        } 
    }
}