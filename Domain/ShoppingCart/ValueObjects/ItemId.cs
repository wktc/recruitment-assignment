using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects.Identifiers;
using Domain.Product.ValueObjects;

namespace Domain.ShoppingCart.ValueObjects
{
    public class ItemId : GuidIdValueObject
    {
        public ItemId() : base()
        {
        }

        public ItemId(Guid id) : base(id)
        {
        }

        public static ItemId CreateOrNull(Guid? id) => id is null ? null : new ItemId(id.Value);
    }
}
