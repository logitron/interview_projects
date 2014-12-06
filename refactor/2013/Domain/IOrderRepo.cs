using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IOrderRepo
    {
        IList<Order> GetOrders();
        void Save(Order order);
    }
}
