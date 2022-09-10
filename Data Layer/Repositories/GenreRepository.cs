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
    public class GenreRepository : IGenreRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public GenreRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAllWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByIdWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
