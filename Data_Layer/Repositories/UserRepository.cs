using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> userManager;

        public UserRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(User entity)
        {
            await gameStoreDbContext.Users.AddAsync(entity);
        }

        public async Task Delete(User entity)
        {
            await Task.Run(() => userManager.DeleteAsync(entity.IdentityUser));
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
            return await gameStoreDbContext.Users
                .Include(u => u.Comments)
                .Include(u => u.Person)
                .Include(u => u.IdentityUser)
                .Include(u => u.Role)
                .Include(u => u.Orders)
                .ToListAsync();
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await gameStoreDbContext.Users.FirstOrDefaultAsync(u => u.IdentityUser.UserName == userName);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Users.FindAsync(id);
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Users
                .Include(u => u.Comments)
                .Include(u => u.Person)
                .Include(u => u.Role)
                .Include(u => u.IdentityUser)
                .Include(u => u.Orders)
                .FirstAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetByRoleIdAsync(int roleId)
        {
            return await gameStoreDbContext.Users.Where(u => u.RoleId == roleId).ToListAsync();
        }

        public async Task Update(User entity)
        {
            await Task.Run(() => gameStoreDbContext.Update(entity));
        }
    }
}
