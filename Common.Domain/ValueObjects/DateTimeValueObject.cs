using System;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class DateTimeValueObject : SingleValuedValueObject<DateTime>, IComparable, IComparable<DateTimeValueObject>
    {
        private static readonly DateTime MinDateTime = new DateTime(1899, 1, 1);
        private static readonly DateTime MaxDateTime = new DateTime(2101, 1, 1);

        protected DateTimeValueObject()
        {
        }

        protected DateTimeValueObject(DateTime value)
            : base(value)
        {
            if (value < MinDateTime || value > MaxDateTime)
            {
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is out of range: <{MinDateTime},{MaxDateTime}>");
            }
        }

        public bool IsBetween(DateTimeValueObject previous, DateTimeValueObject next) => (previous == null || IsAfter(previous)) && (next == null || IsBefore(next));

        public bool IsBefore(DateTimeValueObject other) => CompareTo(other) < 0;
        public bool IsAfter(DateTimeValueObject other) => CompareTo(other) > 0;

        public static int Compare(DateTimeValueObject left, DateTimeValueObject right)
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

            var other = obj as DateTimeValueObject ?? throw new ArgumentException("A DateValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(DateTimeValueObject other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return DateTime.Compare(Value, other.Value);
        }

        public static bool operator <(DateTimeValueObject left, DateTimeValueObject right) => Compare(left, right) < 0;
        public static bool operator >(DateTimeValueObject left, DateTimeValueObject right) => Compare(left, right) > 0;

        public static bool operator <=(DateTimeValueObject left, DateTimeValueObject right) => Compare(left, right) <= 0;
        public static bool operator >=(DateTimeValueObject left, DateTimeValueObject right) => Compare(left, right) >= 0;
        
        public override string ToString() => Value.ToString("dd-MM-yyyy HH:mm:ss");
    }
}
