using Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Test
{
    public class OrderControllerTests
    {
        private readonly Mock<IServiceManager> _mockService;
        private readonly OrderController _controller;
        private CancellationTokenSource _source;
        public OrderControllerTests()
        {
            _mockService = new Mock<IServiceManager>();
            _controller = new OrderController(_mockService.Object);
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnsViewForIndex()
        {
            _source = new CancellationTokenSource();
            CancellationToken token = _source.Token;
          
            var createDto = new OrderForCreationDto { CreateBy = "boffincenter@gmail.com", OderNo = "123345", Price = 456,
                ProductName = "Laptop", Total = 34545, TotalPrice = 34544 };

            _mockService.Setup(service => service.OrderService.CreateAsync(It.IsAny<OrderForCreationDto>(),
      It.IsAny<CancellationToken>())).ReturnsAsync(new ApiResponseDto());

            var result = await _controller.CreateOrder(createDto);
            Assert.IsType<OkObjectResult>(result);
           
        }
        [Fact]
        public async void Create_InvalidModelState_CreateOrderNeverExecutes()
        {
            _source = new CancellationTokenSource();
            //CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = _source.Token;

            ApiResponseDto? responseDto = null;
           
            var createDto = new OrderForCreationDto
            {
                CreateBy = "boffincenter@gmail.com",
                OderNo = "123345",
                Price = 456,
                ProductName = "Laptop",
                Total = 34545,
                TotalPrice = 34544
            };

            _mockService.Setup(service => service.OrderService.CreateAsync(It.IsAny<OrderForCreationDto>(),
       It.IsAny<CancellationToken>())).ReturnsAsync(new ApiResponseDto());          
          

            _controller.ModelState.AddModelError("Name", "Name is required");

         

           await  _controller.CreateOrder(createDto);

            _mockService.Verify(x => x.OrderService.CreateAsync(createDto, token).Result, Times.Never);
        }
    }
}
