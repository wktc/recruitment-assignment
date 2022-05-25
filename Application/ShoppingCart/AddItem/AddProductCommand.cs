using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.ShoppingCart.AddItem
{
    public class AddProductCommand : IRequest
    {
        public Guid ProductId { get; }

        public AddProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
