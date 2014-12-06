using System.Collections.Generic;

namespace Domain
{
    public class MockOrderRepo : IOrderRepository
    {
        public IList<Order> orders;

        public MockOrderRepo()
        {
            orders = new List<Order>();                 
        }     

        public void Save(Order order)
        {
            var order_count = orders.Count;
            order.id = order_count + 1;
            orders.Add(order);                 
        }

        public IList<Order> GetOrders()
        {
            return orders;
        } 
    }
}