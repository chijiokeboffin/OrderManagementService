using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        public IOrderRepository OrderRepository { get; }
        public IPersonRepository PersonRepository { get; }

        public IUnitOfWork UnitOfWork { get; }
    }
}
