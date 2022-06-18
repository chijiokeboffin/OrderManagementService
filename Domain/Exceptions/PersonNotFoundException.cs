using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class PersonNotFoundException : NotFoundException
    {
        public PersonNotFoundException(string email)
      : base($"The owner with the identifier {email} was not found.")
        {
        }
    }
}
