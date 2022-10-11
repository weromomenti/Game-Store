using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Data_Layer.Entities
{
    public class User : BaseEntity
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public string Avatar { get; set; }
        public Person? Person { get; set; }
        public UserIdentity Identity { get; set; }
        public Role? Role { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
