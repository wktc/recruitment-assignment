using System.Collections.Generic;

namespace Common.Domain.ValueObjects.Money
{
    public abstract class MoneyValueObject : DecimalValueObject
    {
        private static readonly int _precision = 2;

        protected MoneyValueObject(): base(_precision)
        {
        }

        protected MoneyValueObject(decimal value, decimal minValue = 0m, decimal maxValue = 99999999999.99m) 
            : base(value, _precision, minValue, maxValue)
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
