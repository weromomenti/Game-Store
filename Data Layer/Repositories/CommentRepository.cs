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
    public class CommentRepository : ICommentRepository
    {
        private readonly GameStoreDbContext gameStoreDbContext;

        public CommentRepository(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
        }
        public async Task AddAsync(Comment entity)
        {
            await gameStoreDbContext.Comments.AddAsync(entity);
        }

        public async void Delete(Comment entity)
        {
            gameStoreDbContext.Comments.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var comment = await gameStoreDbContext.Comments.FindAsync(id);
            gameStoreDbContext.Comments.Remove(comment);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await gameStoreDbContext.Comments.ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllWithDetailsAsync()
        {
            return await gameStoreDbContext.Comments.Include(c => c.Game).Include(c => c.User).Include(c => c.Replies).ToListAsync();
        }

        public async Task<Comment> GetByGameIdAsync(int gameId)
        {
            return await gameStoreDbContext.Comments.FirstAsync(c => c.GameId == gameId);
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await gameStoreDbContext.Comments.FindAsync(id);
        }

        public async Task<Comment> GetByIdWithDetailsAsync(int id)
        {
            return await gameStoreDbContext.Comments.Include(c => c.Game).Include(c => c.User).Include(c => c.Replies).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetByUserIdAsync(int userId)
        {
            return await gameStoreDbContext.Comments.Where(c => c.UserId == userId).ToListAsync();
        }

        public void Update(Comment entity)
        {
            gameStoreDbContext.Comments.Update(entity);
        }
    }
}
