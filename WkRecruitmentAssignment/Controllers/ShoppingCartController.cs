using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ShoppingCart.AddItem;
using Application.ShoppingCart.UseDiscountCode;
using MediatR;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPut("AddProduct")]
        public async Task AddProduct(Guid productId)
        {
            var result = await _mediator.Send(new AddProductCommand(productId));
        }

        [HttpPut("UseDiscountCode")]
        public async Task UseDiscountCode(string code)
        {
            var result = await _mediator.Send(new UseDiscountVoucherCommand(code));
        }
    }
}
