using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Domain.Product.ValueObjects;

namespace Domain.Product
{
    public interface IProductRepository : IRepository<Product, ProductId>
    {
    }
}
