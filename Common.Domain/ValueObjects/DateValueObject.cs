using System;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class DateValueObject : DateTimeValueObject, IComparable, IComparable<DateValueObject> //todo jk podziedziczylem po datetime - sprawdzic czy dobrze
    {
        private static readonly DateTime MinDate = new DateTime(1899, 1, 1);
        private static readonly DateTime MaxDate = new DateTime(2100, 12, 31);

        protected DateValueObject()
        {
        }

        protected DateValueObject(DateTime value)
            : base(value)
        {
            if (!IsDateOnly(value))
                throw new InvalidValueObjectDomainException(GetType().Name, $"Given value ({value}) should contain only date");

            if (value < MinDate || value > MaxDate)
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is out of range <{MinDate}, {MaxDate}>");
        }

        private bool IsDateOnly(DateTime value)
        {
            var date = value.Date;

            return value.Equals(date);
        }
        

        public bool IsBetween(DateValueObject previous, DateValueObject next) => (previous == null || IsAfter(previous)) && (next == null || IsBefore(next));

        public bool IsSameAs(DateValueObject other) => CompareTo(other) == 0;
        public bool IsBefore(DateValueObject other) => CompareTo(other) < 0;
        public bool IsAfter(DateValueObject other) => CompareTo(other) > 0;

        public static int Compare(DateValueObject left, DateValueObject right)
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

            var other = obj as DateValueObject ?? throw new ArgumentException("A DateValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(DateValueObject other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return DateTime.Compare(Value, other.Value);
        }

        public static bool operator <(DateValueObject left, DateValueObject right) => Compare(left, right) < 0;
        public static bool operator >(DateValueObject left, DateValueObject right) => Compare(left, right) > 0;

        public static bool operator <=(DateValueObject left, DateValueObject right) => Compare(left, right) <= 0;
        public static bool operator >=(DateValueObject left, DateValueObject right) => Compare(left, right) >= 0;


        public override string ToString() => Value.ToString("dd-MM-yyyy");
    }
}
