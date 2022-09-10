using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        IGenreRepository GenreRepository { get; }
        IPEGIRatingRepository PEGIRatingRepository { get; }
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        IPersonRepository PersonRepository { get; }
        IRoleRepository RoleRepository { get; }
        ICartRepository CartRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        Task SaveChangesAsync();
    }
}
