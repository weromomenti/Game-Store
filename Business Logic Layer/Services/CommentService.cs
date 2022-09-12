using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    internal class CommentService : ICommentService
    {
        public Task AddAsync(CommentModel model)
        {
            throw new NotImplementedException();
        }

        public Task AddDislikeAsync(int commendId)
        {
            throw new NotImplementedException();
        }

        public Task AddLikeAsync(int commendId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommentModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CommentModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDislikeAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLikeAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CommentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
