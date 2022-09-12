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
    public class PEGIRatingRepository : IPEGIRatingRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public PEGIRatingRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(PEGIRating entity)
        {
            await gameStoreDbContext.PEGIRatings.AddAsync(entity);
        }

        public void Delete(PEGIRating entity)
        {
            gameStoreDbContext.PEGIRatings.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var pegiRating = await gameStoreDbContext.PEGIRatings.FindAsync(id);
            gameStoreDbContext.PEGIRatings.Remove(pegiRating);
        }

        public async Task<IEnumerable<PEGIRating>> GetAllAsync()
        {
            return await gameStoreDbContext.PEGIRatings.ToListAsync();
        }

        public async Task<PEGIRating> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.PEGIRatings.FindAsync(id);
        }

        public void Update(PEGIRating entity)
        {
            gameStoreDbContext.PEGIRatings.Update(entity);
        }
    }
}
