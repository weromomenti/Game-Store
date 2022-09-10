using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public Game? Game { get; set; }
        public User? User { get; set; }
        public ICollection<Comment> Replies { get; set; }
    }
}
