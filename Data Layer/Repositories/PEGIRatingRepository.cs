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
    public class PEGIRatingRepository : IPEGIRatingRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public PEGIRatingRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(PEGIRating entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(PEGIRating entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PEGIRating>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PEGIRating> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PEGIRating entity)
        {
            throw new NotImplementedException();
        }
    }
}
