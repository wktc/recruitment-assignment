using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects.Money;

namespace Domain.Common
{
    public class Money : MoneyValueObject
    {
        public Money(decimal value) : base(value, 0m, 99999999999.99m)
        {
        }
        
    }
}
