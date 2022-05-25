using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects;
using Domain.Common;
using Domain.Product.ValueObjects;

namespace Domain.ShoppingCart.ValueObjects
{
    public class ItemValueObject : ValueObject
    {
        public ProductId ProductId { get; set; }
        public Amount Amount { get; }

        public ItemValueObject(ProductId productId, Amount amount)
        {   
            ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
