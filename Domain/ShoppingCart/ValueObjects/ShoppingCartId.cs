using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects.Identifiers;

namespace Domain.ShoppingCart.ValueObjects
{
    public class ShoppingCartId : GuidIdValueObject
    {
        public ShoppingCartId() : base()
        {
        }

        public ShoppingCartId(Guid id) : base(id)
        {
        }

        public static ShoppingCartId CreateOrNull(Guid? id) => id is null ? null : new ShoppingCartId(id.Value);
    }
}
