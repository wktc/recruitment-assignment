using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain.ActionContext;
using Domain.DiscountVoucher;
using Domain.DiscountVoucher.ValueObjects;
using Domain.ShoppingCart;
using MediatR;

namespace Application.ShoppingCart.UseDiscountCode
{
    public class UseDiscountVoucherCommandHandler : IRequestHandler<UseDiscountVoucherCommand>
    {
        private readonly IDiscountVoucherRepository _discountVoucherRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IActionContextProvider _actionContextProvider;

        public UseDiscountVoucherCommandHandler(
            IDiscountVoucherRepository discountVoucherRepository,
            IShoppingCartRepository shoppingCartRepository, 
            IActionContextProvider actionContextProvider)
        {
            _discountVoucherRepository = discountVoucherRepository ?? throw new ArgumentNullException(nameof(discountVoucherRepository));
            _shoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
            _actionContextProvider = actionContextProvider ?? throw new ArgumentNullException(nameof(actionContextProvider));
        }

        public async Task<Unit> Handle(UseDiscountVoucherCommand command, CancellationToken cancellationToken)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var discountCode = await _discountVoucherRepository.GetByCodeAsync(Code.CreateOrNull(command.Code));
            var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(_actionContextProvider.ActionContext.UserId);
            shoppingCart.UseDiscountCode(discountCode.Id);
            return Unit.Value;
        }
    }
}
