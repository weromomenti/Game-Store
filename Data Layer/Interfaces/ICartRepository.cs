using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetAllWithDetailsAsync();
        Task<Cart> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Cart>> GetByUserIdAsync(int userId);
    }
}
