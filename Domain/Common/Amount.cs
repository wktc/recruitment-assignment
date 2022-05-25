using Common.Domain.ValueObjects;

namespace Domain.Common
{
    public class Amount : IntegerValueObject
    {
        public Amount()
        {
        }

        public Amount(int value) : base(value, 1, 999)
        {
        }

        public static Amount CreateOrNull(int? value) => value is not null ? new(value.Value) : null;

        public Amount Increase()
        {
            return CreateOrNull(Value + 1);
        }
        
    }
}
