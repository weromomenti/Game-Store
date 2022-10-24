using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IUserService : ICrud<UserModel>
    {
        Task<User> GetByUserNameAsync(string userName);
        Task AddUserToRoleAsync(int userId, int roleId);
    }
}
