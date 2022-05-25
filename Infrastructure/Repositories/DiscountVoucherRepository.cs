using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.DiscountVoucher;
using Domain.DiscountVoucher.ValueObjects;

namespace Infrastructure.Repositories
{
    public class DiscountVoucherRepository : Repository<DiscountVoucher, DiscountVoucherId>, IDiscountVoucherRepository
    {
        public DiscountVoucherRepository()
        {
            Collection.Add(new DiscountVoucher(ExpirationDate.CreateOrNull(DateTime.UtcNow.Date.AddDays(1)), new Code("abcdef"), new Money(5)));
            Collection.Add(new DiscountVoucher(ExpirationDate.CreateOrNull(DateTime.UtcNow.Date.AddDays(-1)), new Code("qwerty"), new Money(2)));
            Collection.Add(new DiscountVoucher(ExpirationDate.CreateOrNull(DateTime.UtcNow.Date.AddDays(1)), new Code("xyzxyz"), new Money(7)));
        }

        async public Task<DiscountVoucher> GetByCodeAsync(Code code)
        {
            var discountVoucher =  Collection.SingleOrDefault(x => x.Code.Equals(code));
            if (discountVoucher is null)
            {
                throw new ApplicationException($"Cannot find discout voucher: {code}");
            }

            return discountVoucher;
        }
    }
}
