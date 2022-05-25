using System;
using Common.Domain.ValueObjects.Identifiers;

namespace Domain.DiscountVoucher.ValueObjects
{
    public class DiscountVoucherId : GuidIdValueObject
    {
        public DiscountVoucherId() : base()
        {
        }

        public DiscountVoucherId(Guid id) : base(id)
        {
        }

        public static DiscountVoucherId CreateOrNull(Guid? id) => id is null ? null : new DiscountVoucherId(id.Value);
    }
}
