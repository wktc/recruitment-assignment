namespace Common.Domain.ValueObjects
{
    public abstract class ProcentValueObject : DecimalValueObject
    {
        private static readonly int Precision = 2;

        protected ProcentValueObject(): base(Precision)
        {
        }

        protected ProcentValueObject(decimal value) : base(value, Precision, 0.01m, 100.00m)
        {
        }
    }
}