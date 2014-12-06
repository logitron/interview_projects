using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IProductRepo
    {
        IList<Item> GetItems();
    }
}
