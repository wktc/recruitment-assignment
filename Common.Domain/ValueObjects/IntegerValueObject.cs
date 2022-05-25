using System;
using System.Globalization;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class IntegerValueObject : SingleValuedValueObject<int>, IComparable, IComparable<IntegerValueObject>
    {
        private static readonly NumberFormatInfo NumberFormatInfo = new NumberFormatInfo
        {
            NumberGroupSizes = new int[0]
        };

        protected IntegerValueObject()
        {
        }

        protected IntegerValueObject(int value, int? minValue = null, int? maxValue = null): base(value) //todo jk testy + poprawić w kadrach
        {
            maxValue ??= int.MaxValue;
            minValue ??= int.MinValue;

            if (value < minValue.Value)
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too small. Value must be greater or equal {minValue}");

            if (value > maxValue.Value)
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too big. Value must be less or equal {maxValue}");
        }

        public static int Compare(IntegerValueObject left, IntegerValueObject right)
        {
            if (ReferenceEquals(left, right))
            {
                return 0;
            }

            return left?.CompareTo(right) ?? -1;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var other = obj as IntegerValueObject ?? throw new ArgumentException("A IntegerValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(IntegerValueObject other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return Value.CompareTo(other.Value);
        }

        public override string ToString() => Value.ToString(NumberFormatInfo);
    }
}
