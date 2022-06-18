using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos
{
    public class OrderDto
    {
      
      
        public Guid Id { get; set; } = Guid.NewGuid();
        [CheckDateRangeAttribute]
        public DateTime OrderDate { get; set; }
        [Required]
        public string CreateBy { get; set; }
        public string OderNo { get; set; }
        public string ProductName { get; set; }
        public decimal Total { get; set; }
        public long Price { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid PersonId { get; set; }
    }
}
