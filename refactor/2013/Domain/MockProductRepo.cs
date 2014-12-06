using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class MockProductRepo : IProductRepo
    {
        public IList<Item> GetItems()
        {
            return new List<Item>()
            {
                new Item(){description = "Red Stapler",price = 50, id = 1},
                new Item(){description = "TPS Report", price = 3, id = 2},
                new Item(){description = "Printer", price = 400, id = 3},
                new Item(){description = "Baseball bat", price = 80, id = 4},
                new Item(){description = "Michael Bolton CD", price = 12, id = 5}
            };
        }
    }
}
