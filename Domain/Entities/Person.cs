using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {       
        public Guid Id { get; set; }       
        public string Name { get; set; }
      
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
       
    }
}
