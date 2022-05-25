using Common.Domain.ValueObjects;

namespace Domain.DiscountVoucher.ValueObjects
{
    public class Code : StringValueObject
    {
        public Code() : base()
        {
        }

        public Code(string value) : base(value, 6, 6)
        {
        }

        public static Code CreateOrNull(string code) => code is null ? null : new Code(code);
    }
}
