using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(Person entity)
        {
            await gameStoreDbContext.Persons.AddAsync(entity);
        }

        public async Task Delete(Person entity)
        {
            await Task.Run(() => gameStoreDbContext.Persons.Remove(entity));
        }

        public async Task DeleteByIdAsync(int id)
        {
            var person = await gameStoreDbContext.Persons.FindAsync(id);
            gameStoreDbContext.Persons.Remove(person);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await gameStoreDbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Persons.FindAsync(id);
        }

        public async Task Update(Person entity)
        {
            await Task.Run (() => gameStoreDbContext.Persons.Update(entity));
        }
    }
}
