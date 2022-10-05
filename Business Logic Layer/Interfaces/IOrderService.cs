using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IOrderService : ICrud<OrderModel>
    {
        Task AddGameAsync(int id, int gameId);
        Task RemoveGameAsync(int id, int gameId);
        Task<IEnumerable<OrderDetailsModel>> GetAllOrderDetailsAsync();
        Task<OrderDetailsModel> GetOrderDetailsByIdAsync(int id);
        Task CheckoutAsync(int id);
    }
}
