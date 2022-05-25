using System.Globalization;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class LongValueObject : SingleValuedValueObject<long>
    {
        private static readonly NumberFormatInfo NumberFormatInfo = new NumberFormatInfo
        {
            NumberGroupSizes = new int[0]
        };

        protected LongValueObject()
        {
        }

        protected LongValueObject(long value, long minValue, long maxValue) : base(value)
        {

            if (value < minValue)
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too small. Value must be greater or equal {minValue}");

            if (value > maxValue)
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too big. Value must be less or equal {maxValue}");
        }

        public override string ToString() => Value.ToString(NumberFormatInfo);
    }
}
