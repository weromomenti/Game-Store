using AutoMapper;
using Business_Logic_Layer.Infrastructure;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    internal class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly C

        public CartService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public Task AddAsync(CartModel model)
        {
            if (model)
            {
                throw new GameStoreException();
            }
        }

        public Task AddGameAsync(int gameId, int cartId)
        {
            throw new NotImplementedException();
        }

        public Task CheckoutAsync(CartModel cartModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveGameAsync(int gameId, int cartId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CartModel model)
        {
            throw new NotImplementedException();
        }
    }
}
