using AutoMapper;
using Domain.RepositoryInterfaces;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _lazyOrderService;
        private readonly Lazy<IPersonService> _lazyPersonService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper));
            _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager, mapper));
        }

        public IOrderService OrderService => _lazyOrderService.Value;
        public IPersonService PersonService => _lazyPersonService.Value;       
    }
}
