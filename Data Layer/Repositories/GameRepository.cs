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
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public GameRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(Game entity)
        {
            await gameStoreDbContext.Games.AddAsync(entity);
        }

        public void Delete(Game entity)
        {
            gameStoreDbContext.Games.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var game = await gameStoreDbContext.Games.FindAsync(id);
            gameStoreDbContext.Games.Remove(game);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await gameStoreDbContext.Games.ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetAllWithDetailsAsync()
        {
            return await gameStoreDbContext.Games.Include(g => g.Genres).Include(g => g.Comments).Include(g => g.PEGIRating).ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Games.FindAsync(id);
        }

        public async Task<Game> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Games.Include(g => g.Genres).Include(g => g.Comments).Include(g => g.PEGIRating).FirstAsync(g => g.Id == id);
        }

        public void Update(Game entity)
        {
            gameStoreDbContext.Games.Update(entity);
        }
    }
}
