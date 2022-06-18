using Domain.RepositoryInterfaces;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager: IRepositoryManager
    {
        private readonly Lazy<IOrderRepository> _lazyOrderRepository;
        private readonly Lazy<IPersonRepository> _lazyPersonRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        public RepositoryManager(RepositoryDbContext context)
        {
            _lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
            _lazyPersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;
        public IPersonRepository PersonRepository => _lazyPersonRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

       
    }
}
