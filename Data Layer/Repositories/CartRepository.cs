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
    public class CartRepository : ICartRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public CartRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(Cart entity)
        {
            await gameStoreDbContext.Carts.AddAsync(entity);
        }

        public void Delete(Cart entity)
        {
            gameStoreDbContext.Carts.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var cart = await gameStoreDbContext.Carts.FindAsync(id);
            gameStoreDbContext.Carts.Remove(cart);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await gameStoreDbContext.Carts.ToListAsync();
        }

        public async Task<IEnumerable<Cart>> GetAllWithDetailsAsync()
        {
            return await gameStoreDbContext.Carts.Include(c => c.User).Include(c => c.Games).ToListAsync();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Carts.FindAsync(id);
        }

        public async Task<Cart> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Carts.Include(c => c.User).Include(c => c.Games).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cart>> GetByUserIdAsync(int userId)
        {
            return await gameStoreDbContext.Carts.Where(c => c.UserId == userId).ToListAsync();
        }

        public void Update(Cart entity)
        {
            gameStoreDbContext.Carts.Update(entity);
        }
    }
}
