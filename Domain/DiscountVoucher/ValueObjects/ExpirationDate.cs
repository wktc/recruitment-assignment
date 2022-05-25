using System;
using Common.Domain.ValueObjects;

namespace Domain.DiscountVoucher.ValueObjects
{
    public class ExpirationDate : DateValueObject
    {
        public ExpirationDate() : base()
        {
        }

        public ExpirationDate(DateTime date) : base(date)
        {
        }

        public static ExpirationDate CreateOrNull(DateTime? date) => date is null ? null : new ExpirationDate(date.Value);
    }
}
