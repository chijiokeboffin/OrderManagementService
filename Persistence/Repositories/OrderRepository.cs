using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OrderRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;     

        public async Task<IEnumerable<Order>> GetAllByPersonEmailAsync(string createdBy,  CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders.Where(x => x.CreateBy == createdBy).ToListAsync(cancellationToken);
        }

        public async Task<Order> GetByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == orderId, cancellationToken);
        }
        public async Task<bool> IsOrderNumberExistAsync(string orderNo, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Orders.AnyAsync(order => order.OderNo.Equals(orderNo), cancellationToken);
        }

        public void Insert(Order order)
        {
            _dbContext.Orders.Add(order);
        }
        public void Remove(Order order)
        {
            _dbContext.Orders.Remove(order);
        }
    }
}
