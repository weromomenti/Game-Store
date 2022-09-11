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
    public class OrderRepository : IOrderRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public OrderRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(Order entity)
        {
            await gameStoreDbContext.Orders.AddAsync(entity);
        }

        public void DeleteAsync(Order entity)
        {
            gameStoreDbContext.Orders.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var order = await gameStoreDbContext.Orders.FindAsync(id);
            gameStoreDbContext.Orders.Remove(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await gameStoreDbContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await gameStoreDbContext.Orders.Include(o => o.User).Include(o => o.OrderDetails).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Orders.FindAsync(id);
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Orders.Include(o => o.User).Include(o => o.OrderDetails).FirstAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await gameStoreDbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public void Update(Order entity)
        {
            gameStoreDbContext.Orders.Update(entity);
        }
    }
}
