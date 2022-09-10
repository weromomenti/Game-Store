using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public PersonRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
