using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
   
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllByPersonEmailAsync(string createdBy, CancellationToken cancellationToken = default);
        Task<Order> GetByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
        Task<bool> IsOrderNumberExistAsync(string orderNo, CancellationToken cancellationToken = default);
        void Insert(Order order);
        
    }
}
