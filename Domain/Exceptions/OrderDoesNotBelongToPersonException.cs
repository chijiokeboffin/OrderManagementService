using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class OrderDoesNotBelongToPersonException : BadRequestException
    {
        public OrderDoesNotBelongToPersonException(Guid orderId, string email)
        : base($"The order with the identifier {orderId} does not belong to the person with the identifier {email}")
        {
        }
    }
}
