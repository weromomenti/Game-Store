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
    public class GenreRepository : IGenreRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public GenreRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(Genre entity)
        {
            await gameStoreDbContext.AddAsync(entity);
        }

        public void Delete(Genre entity)
        {
            gameStoreDbContext.Genres.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var genre = await gameStoreDbContext.Genres.FindAsync(id);
            gameStoreDbContext.Genres.Remove(genre);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await gameStoreDbContext.Genres.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllWithDetailsAsync()
        {
            return await gameStoreDbContext.Genres.Include(g => g.Games).ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Genres.FindAsync(id);
        }

        public async Task<Genre> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Genres.Include(g => g.Games).FirstAsync(g => g.Id == id);
        }

        public void Update(Genre entity)
        {
            gameStoreDbContext.Genres.Update(entity);
        }
    }
}
