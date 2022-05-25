using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects.Identifiers;

namespace Domain.Product.ValueObjects
{
    public class ProductId : GuidIdValueObject
    {
        public ProductId() : base()
        {
        }

        public ProductId(Guid id) : base(id)
        {
        }

        public static ProductId CreateOrNull(Guid? id) => id is null ? null : new ProductId(id.Value);
    }
}
