using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IProductRepo
    {
        IList<Item> GetItems();
    }
}
