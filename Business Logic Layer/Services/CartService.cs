using AutoMapper;
using Business_Logic_Layer.Infrastructure;
using Business_Logic_Layer.Infrastructure.Validators;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly CartValidator validator;

        public CartService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            validator = new CartValidator();
        }

        public async Task AddAsync(CartModel model)
        {
            await unitOfWork.CartRepository.AddAsync(mapper.Map<Cart>(model));
        }

        public Task AddGameAsync(int gameId, int cartId)
        {
            throw new NotImplementedException();
        }

        public Task CheckoutAsync(CartModel cartModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.CartRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<CartModel>> GetAllAsync()
        {
            var carts = await unitOfWork.CartRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CartModel>>(carts);
        }

        public async Task<CartModel> GetByIdAsync(int id)
        {
            var cart = await unitOfWork.CartRepository.GetByIdAsync(id);
            return mapper.Map<CartModel>(cart);
        }

        public Task RemoveGameAsync(int gameId, int cartId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CartModel model)
        {
            await Task.Run(() => unitOfWork.CartRepository.Update(mapper.Map<Cart>(model)));
        }
    }
}
