using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IOrderRepository
    {
        IList<Order> GetOrders();
        void Save(Order order);
    }
}
