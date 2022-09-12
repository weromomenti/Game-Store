using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    internal interface ICommentService : ICrud<CommentModel>
    {
        Task AddLikeAsync(int commendId);
        Task RemoveLikeAsync(int commentId);
        Task AddDislikeAsync(int commendId);
        Task RemoveDislikeAsync(int commentId);
    }
}
