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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public OrderDetailsRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(OrderDetails entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(OrderDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetails>> GetAllWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
