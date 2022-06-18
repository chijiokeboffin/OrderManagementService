using Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<ApiResponseDto> GetAllByPersonEmailAsync(string createdBy, CancellationToken cancellationToken = default);
        Task<OrderDto> GetByIdAsync(Guid orderId, string createdBy, CancellationToken cancellationToken = default);
        Task<ApiResponseDto> CreateAsync(OrderForCreationDto ownerForCreationDto, CancellationToken cancellationToken = default);             
    }
}
