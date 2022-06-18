using Contracts;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {       
        public Guid Id { get; set; }       
        public DateTime OrderDate { get; set; }       
        public string CreateBy { get; set; }
        public string OderNo { get; set; }
        public string ProductName { get; set; }
        public decimal Total { get; set; }
        public long  Price { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid PersonId { get; set; }
    }
}

