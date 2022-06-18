using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos
{
    public class OrderForCreationDto
    {
        [Required]
        public string CreateBy { get; set; }
        [Required]
        public string OderNo { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
