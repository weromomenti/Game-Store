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
    public class UserRepository : IUserRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public UserRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(User entity)
        {
            await gameStoreDbContext.Users.AddAsync(entity);
        }

        public void Delete(User entity)
        {
            gameStoreDbContext.Users.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var user = await gameStoreDbContext.Users.FindAsync(id);
            gameStoreDbContext.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await gameStoreDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithDetailsAync()
        {
            return await gameStoreDbContext.Users.Include(u => u.Cart).Include(u => u.Comments).Include(u => u.Person).Include(u => u.Role).ToListAsync();
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await gameStoreDbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Users.FindAsync(id);
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Users.Include(u => u.Cart).Include(u => u.Comments).Include(u => u.Person).Include(u => u.Role).FirstAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetByRoleIdAsync(int roleId)
        {
            return await gameStoreDbContext.Users.Where(u => u.RoleId == roleId).ToListAsync();
        }

        public void Update(User entity)
        {
            gameStoreDbContext.Update(entity);
        }
    }
}
