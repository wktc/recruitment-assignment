using System;
using MediatR;

namespace Application.ShoppingCart.UseDiscountCode
{
    public class UseDiscountVoucherCommand : IRequest
    {
        public string Code { get; }

        public UseDiscountVoucherCommand(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}
