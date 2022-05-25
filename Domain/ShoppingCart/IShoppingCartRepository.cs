using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.User.ValueObjects;
using Domain.ShoppingCart.ValueObjects;

namespace Domain.ShoppingCart
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart, ShoppingCartId>
    {
        Task<ShoppingCart> GetByUserIdAsync(UserId userId);
    }
}
