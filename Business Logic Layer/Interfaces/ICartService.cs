using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface ICartService : ICrud<CartModel>
    {
        Task AddGameAsync(int gameId, int cartId);
        Task RemoveGameAsync(int gameId, int cartId);
        Task CheckoutAsync(CartModel cartModel);
    }
}
