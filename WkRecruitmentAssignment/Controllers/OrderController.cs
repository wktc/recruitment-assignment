using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Order.Create;
using Application.ShoppingCart.AddItem;
using Application.ShoppingCart.UseDiscountCode;
using MediatR;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        [HttpPost("Create")]
        public async Task<Guid> Create(Guid shoppingCartId, string paymentMethod, string remarks)
        {
            if (!Enum.TryParse(paymentMethod, out PaymentMethod paymentMethodEnum))
            {
                throw new ArgumentException("Wrong payment method value.");
            }

            var createRequest = new CreateRequest(shoppingCartId, paymentMethodEnum, remarks);
            throw new NotImplementedException();
        }
    }
}
