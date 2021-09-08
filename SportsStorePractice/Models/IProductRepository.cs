using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStorePractice.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
