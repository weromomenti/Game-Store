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
    public class CommentRepository : ICommentRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public CommentRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public Task AddAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByGameIdAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
