using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data_Layer.Entities
{
    public class Role : BaseEntity
    {
        public int RoleIdentityId { get; set; }
        public IdentityRole IdentityRole { get; set; }
    }
}
