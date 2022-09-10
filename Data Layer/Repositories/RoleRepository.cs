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
    public class RoleRepository : IRoleRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public RoleRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
