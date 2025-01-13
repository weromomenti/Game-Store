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
    public class RoleRepository : IRoleRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public RoleRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(Role entity)
        {
            await gameStoreDbContext.Roles.AddAsync(entity);
        }

        public async Task Delete(Role entity)
        {
            await Task.Run(() => gameStoreDbContext.Roles.Remove(entity));
        }

        public async Task DeleteByIdAsync(int id)
        {
            var role = await gameStoreDbContext.Roles.FindAsync(id);
            gameStoreDbContext.Roles.Remove(role);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await gameStoreDbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Roles.FindAsync(id);
        }

        public async Task Update(Role entity)
        {
            await Task.Run(() => gameStoreDbContext.Roles.Update(entity));
        }
    }
}
