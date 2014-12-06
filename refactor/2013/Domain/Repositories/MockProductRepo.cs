using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    public class MockProductRepo : IProductRepo
    {
        public IList<Item> GetItems()
        {
            return new List<Item>()
            {
                new Item(){ Description = "Red Stapler", Price = 50, Id = 1},
                new Item(){ Description = "TPS Report", Price = 3, Id = 2},
                new Item(){ Description = "Printer", Price = 400, Id = 3},
                new Item(){ Description = "Baseball bat", Price = 80, Id = 4},
                new Item(){ Description = "Michael Bolton CD", Price = 12, Id = 5}
            };
        }
    }
}
