using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IPersonRepository
    {
       
        Task<IEnumerable<Person>> GetAllPeopleAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<Person> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
        void Insert(Person person);
        void Remove(Person person);
    }
}
