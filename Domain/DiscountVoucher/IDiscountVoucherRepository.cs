using System.Threading.Tasks;
using Common.Domain;
using Domain.DiscountVoucher.ValueObjects;

namespace Domain.DiscountVoucher
{
    public interface IDiscountVoucherRepository : IRepository<DiscountVoucher, DiscountVoucherId>
    {
        Task<DiscountVoucher> GetByCodeAsync(Code code);
    }
}
