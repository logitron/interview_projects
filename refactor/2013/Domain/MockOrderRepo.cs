using System.Collections.Generic;

namespace Domain
{
    public class MockOrderRepo : IOrderRepo
    {
        public IList<Order> orders;

        public MockOrderRepo()
        {
            orders = new List<Order>();                 
        }     

        public void Save(Order order)
        {
            var order_count = orders.Count;
            order.Id = order_count + 1;
            orders.Add(order);                 
        }

        public IList<Order> GetOrders()
        {
            return orders;
        } 
    }
}