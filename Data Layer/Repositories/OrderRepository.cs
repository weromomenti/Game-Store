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
    public class OrderRepository : IOrderRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public OrderRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
