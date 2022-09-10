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
    public class CartRepository : ICartRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public CartRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Cart entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAllWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
