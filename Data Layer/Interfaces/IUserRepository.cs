using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithDetailsAync();
        Task<User> GetByIdWithDetailsAsync(int id);
        Task<User> GetByUserNameAsync(string userName);
        Task<IEnumerable<User>> GetByRoleIdAsync(int roleId);
    }
}
