using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain.ActionContext;
using Domain.Product;
using Domain.Product.ValueObjects;
using Domain.ShoppingCart;
using MediatR;

namespace Application.ShoppingCart.AddItem
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IActionContextProvider _actionContextProvider;

        public AddProductCommandHandler(
            IProductRepository productRepository,
            IShoppingCartRepository shoppingCartRepository, 
            IActionContextProvider actionContextProvider)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _shoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
            _actionContextProvider = actionContextProvider ?? throw new ArgumentNullException(nameof(actionContextProvider));
        }

        public async Task<Unit> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var productId = ProductId.CreateOrNull(command.ProductId);
            if (!await _productRepository.ExistsAsync(productId))
            {
                throw new ApplicationException("Product does not exist.");
            }
            var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(_actionContextProvider.ActionContext.UserId);
            shoppingCart.AddProduct(productId);
            return Unit.Value;
        }
    }
}
