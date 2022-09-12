using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    internal class CommentModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public ICollection<int> ReplyIds { get; set; }

    }
}
