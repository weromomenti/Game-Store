using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class User : BaseEntity
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Person Person { get; set; }
        public Role? Role { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
