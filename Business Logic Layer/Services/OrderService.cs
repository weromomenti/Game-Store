using AutoMapper;
using Business_Logic_Layer.Infrastructure;
using Business_Logic_Layer.Infrastructure.Validators;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly OrderValidator orderValidator;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            orderValidator = new OrderValidator();
        }

        public async Task AddAsync(OrderModel model)
        {
            await orderValidator.ValidateAndThrowAsync(model);
            await unitOfWork.OrderRepository.AddAsync(mapper.Map<Order>(model));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<OrderModel> AddGameAsync(int id, int gameId)
        {
            var game = await unitOfWork.GameRepository.GetByIdAsync(gameId);
            if (game == null)
            {
                throw new GameStoreException();
            }
            var order = await unitOfWork.OrderRepository.GetByIdAsync(id);
            var orderDetail = order.OrderDetails.SingleOrDefault(od => od?.Game?.Id == gameId);

            if (orderDetail == null)
            {
                order.OrderDetails.Add(new OrderDetails
                {
                    Game = game,
                    GameId = game.Id,
                    Order = order,
                    OrderId = order.Id,
                    Quantity = 1,
                    UnitPrice = game.Price
                });
            }
            else
            {
                orderDetail.Quantity++;
            }
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<OrderModel>(order);
        }
        public async Task<OrderModel> RemoveGameAsync(int id, int gameId)
        {
            var game = await unitOfWork.GameRepository.GetByIdAsync(gameId);
            if (game == null)
            {
                throw new GameStoreException();
            }
            var order = await unitOfWork.OrderRepository.GetByIdAsync(id);
            var orderDetail = order.OrderDetails.SingleOrDefault(od => od?.Game?.Id == gameId);

            if (orderDetail == null)
            {
                throw new GameStoreException();
            }

            if (orderDetail.Quantity == 1)
            {
                order.OrderDetails.Remove(orderDetail);
            }
            else
            {
                orderDetail.Quantity--;
            }
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<OrderModel>(order);
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.OrderRepository.DeleteByIdAsync(modelId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var orders = await unitOfWork.OrderRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            var orderModel = await unitOfWork.OrderRepository.GetByIdAsync(id);
            return mapper.Map<OrderModel>(orderModel);
        }

        public async Task<IEnumerable<OrderDetailsModel>> GetAllOrderDetailsAsync()
        {
            var orderDetails = await unitOfWork.OrderDetailsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OrderDetailsModel>>(orderDetails);
        }

        public async Task<OrderDetailsModel> GetOrderDetailsByIdAsync(int id)
        {
            var orderDetail = await unitOfWork.OrderDetailsRepository.GetByIdAsync(id);
            return mapper.Map<OrderDetailsModel>(orderDetail);
        }

        public async Task<OrderModel> UpdateAsync(OrderModel model)
        {
            await orderValidator.ValidateAndThrowAsync(model);
            await Task.Run(() => unitOfWork.OrderRepository.Update(mapper.Map<Order>(model)));
            await unitOfWork.SaveChangesAsync();
            return model;
        }

        public async Task CheckoutAsync(int id)
        {
            var order = await unitOfWork.OrderRepository.GetByIdAsync(id);
            order.IsCheckecOut = true;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
