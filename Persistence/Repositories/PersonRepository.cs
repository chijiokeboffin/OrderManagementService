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
    internal sealed class PersonRepository : IPersonRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public PersonRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public async Task<IEnumerable<Person>> GetAllPeopleAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Persons.Skip(pageNo).Take(pageSize).ToListAsync(cancellationToken);
        }
        public async Task<Person> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await  _dbContext.Persons.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
        public void Insert(Person person)
        {
            _dbContext.Persons.Add(person);
        }

        public void Remove(Person person)
        {
            _dbContext.Persons.Remove(person);
        }
    }
}
