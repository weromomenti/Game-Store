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
    public class UserRepository : IUserRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public UserRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllWithDetailsAync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetByRoleIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
