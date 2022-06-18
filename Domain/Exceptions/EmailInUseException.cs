using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class EmailInUseException : BadRequestException
    {
        public EmailInUseException(string message) : base(message)
        {
        }
    }
}
