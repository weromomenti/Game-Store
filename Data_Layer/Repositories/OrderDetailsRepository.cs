using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public OrderDetailsRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(OrderDetails entity)
        {
            await gameStoreDbContext.OrderDetails.AddAsync(entity);
        }

        public async Task Delete(OrderDetails entity)
        {
            await Task.Run(() => gameStoreDbContext.OrderDetails.Remove(entity));
        }

        public async Task DeleteByIdAsync(int id)
        {
            var orderDetail = await gameStoreDbContext.OrderDetails.FindAsync(id);
            gameStoreDbContext.OrderDetails.Remove(orderDetail);
        }

        public async Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            return await gameStoreDbContext.OrderDetails.ToListAsync();
        }

        public async Task<IEnumerable<OrderDetails>> GetAllWithDetailsAsync()
        {
            return await gameStoreDbContext.OrderDetails.Include(od => od.Game).Include(od => od.Order).ToListAsync();
        }

        public async Task<OrderDetails> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.OrderDetails.FindAsync(id);
        }

        public async Task<OrderDetails> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.OrderDetails.Include(od => od.Game).Include(od => od.Order).FirstAsync(od => od.Id == id);
        }

        public async Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(int orderId)
        {
            return await gameStoreDbContext.OrderDetails.Where(od => od.OrderId == orderId).ToListAsync();
        }

        public async Task Update(OrderDetails entity)
        {
            await Task.Run(() => gameStoreDbContext.OrderDetails.Update(entity));
        }
    }
}
