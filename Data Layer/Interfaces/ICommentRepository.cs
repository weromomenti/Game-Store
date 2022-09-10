using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAllWithDetailsAsync();
        Task<Comment> GetByIdWithDetailsAsync(int id);
        Task<Comment> GetByGameIdAsync(int gameId);
        Task<Comment> GetByUserIdAsync(int userId);
    }
}
