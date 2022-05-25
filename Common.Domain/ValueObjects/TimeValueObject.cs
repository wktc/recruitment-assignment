using System;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class TimeValueObject : SingleValuedValueObject<TimeSpan>, IComparable, IComparable<TimeValueObject>
    {
        private static readonly TimeSpan MinTime = new TimeSpan(0, 0, 0);
        private static readonly TimeSpan MaxTime = new TimeSpan(24, 0, 0);

        protected TimeValueObject()
        { }

        protected TimeValueObject(TimeSpan value, TimeSpan minValue, TimeSpan maxValue)
            : base(value)
        {
            if (minValue > maxValue) throw new InvalidValueObjectDomainException(GetType().Name, $"MinValue ({minValue}) can't be greater than MaxValue ({maxValue})");
            if (minValue < MinTime) throw new InvalidValueObjectDomainException(GetType().Name, $"MinValue ({minValue}) is too low. Minimal accepted value ({MinTime})");
            if (maxValue > MaxTime) throw new InvalidValueObjectDomainException(GetType().Name, $"MaxValue ({maxValue}) is too big. Maximal accepted value ({MaxTime})");

            if (value != new TimeSpan(value.Days, value.Hours, value.Minutes, value.Seconds))
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) can't contains fractions of seconds");

            if (value < minValue) throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too low. Minimal accepted value ({minValue})");
            if (value > maxValue) throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too big. Maximal accepted value ({maxValue})");
        }

        public static int Compare(TimeValueObject left, TimeValueObject right)
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

            var other = obj as TimeValueObject ?? throw new ArgumentException("A TimeValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(TimeValueObject other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return TimeSpan.Compare(Value, other.Value);
        }

        public static bool operator <(TimeValueObject left, TimeValueObject right) => Compare(left, right) < 0;
        public static bool operator >(TimeValueObject left, TimeValueObject right) => Compare(left, right) > 0;

        public static bool operator <=(TimeValueObject left, TimeValueObject right) => Compare(left, right) <= 0;
        public static bool operator >=(TimeValueObject left, TimeValueObject right) => Compare(left, right) >= 0;


        public override string ToString() => Value.ToString("hh\\:mm\\:ss");
    }
}
