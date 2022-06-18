using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class DuplicateOrderNumberException: BadRequestException
    {
        public DuplicateOrderNumberException(string message) : base(message)
        {
        }
    }
}
