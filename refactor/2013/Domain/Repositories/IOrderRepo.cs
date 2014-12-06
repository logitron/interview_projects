using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IOrderRepo
    {
        IList<Order> GetOrders();
        void Save(Order order);
    }
}
