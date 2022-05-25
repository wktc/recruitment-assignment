using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Domain.Common;
using Domain.Product.ValueObjects;
using Domain.ShoppingCart.ValueObjects;

namespace Domain.ShoppingCart
{
    public class ShoppingCartItem : Entity<ItemId>
    {
        public ProductId ProductId { get; set; }
        public Amount Amount { get; private set; }
        
        public ShoppingCartItem(ProductId productId)
        {
            ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
            Amount = Amount.CreateOrNull(1);
        }

        public void IncreaseAmount()
        {
            Amount = Amount.Increase();
        }
        
    }
}
