using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        Task<IEnumerable<OrderDetails>> GetAllWithDetailsAsync();
        Task<OrderDetails> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(int orderId);
    }
}
