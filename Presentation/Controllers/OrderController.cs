using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("post-order")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto creationDto)
        {
            var response = await _serviceManager.OrderService.CreateAsync(creationDto);
            return Ok(response);
        }
      

        [HttpGet("get-orders/{email}")]
        public async Task<IActionResult> GetAllOrdersByPersonEmailAsync(string email, CancellationToken cancellationToken)
        {
            var accountDto = await _serviceManager.OrderService.GetAllByPersonEmailAsync(email, cancellationToken);
            return Ok(accountDto);
        }
    }
}
