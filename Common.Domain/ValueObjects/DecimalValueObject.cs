using System;
using System.Globalization;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class DecimalValueObject : SingleValuedValueObject<decimal>
    {
        private readonly int? _precision;

        private static readonly NumberFormatInfo NumberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ",",
            NumberGroupSizes = new int[0]
        };

        protected DecimalValueObject(int? precision)
        {
            _precision = precision;
        }

        protected DecimalValueObject(string value, int? precision, decimal? minValue, decimal? maxValue)
            : this(decimal.Parse(value), precision, minValue, maxValue)
        {
        }

        protected DecimalValueObject(decimal value, int? precision, decimal? minValue, decimal? maxValue) : base(value)
        {
            if (minValue.HasValue && value < minValue.Value) 
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too small. Value must be greater or equal {minValue}");
            
            if (maxValue.HasValue && value > maxValue.Value)
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too big. Value must be less or equal {maxValue}");
            
            if (precision.HasValue && value != Math.Round(value, precision.Value))
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) with too big precision. Max allowed precision: {precision}");

            _precision = precision;
        }

        public override string ToString() => Value.ToString(Format(), NumberFormatInfo);

        protected string Format() => _precision == null
                                        ? $"0.{new string('#', 28)}"
                                        : "0.".PadRight(_precision.Value + 2 /*"0."*/, '0');

    }
}
