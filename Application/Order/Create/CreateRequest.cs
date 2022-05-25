using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Create
{
    public class CreateRequest
    {
        public Guid ShoppingCartId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Remarks { get; set; }
        
        public CreateRequest(Guid shoppingCartId, PaymentMethod paymentMethod, string remarks)
        {
            ShoppingCartId = shoppingCartId;
            PaymentMethod = paymentMethod;
            Remarks = remarks;
        }
    }

    public enum PaymentMethod
    {
        BankTransfer,
        CreditCard
    }
}
