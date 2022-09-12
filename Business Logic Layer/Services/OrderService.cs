using AutoMapper;
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
    internal class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly OrderValidator validator;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new OrderValidator();
        }

        public async Task AddAsync(OrderModel model)
        {
            await unitOfWork.OrderRepository.AddAsync(mapper.Map<Order>(model));
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.OrderRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var orders = await unitOfWork.OrderRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await unitOfWork.OrderRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(OrderModel model)
        {
            await Task.Run(() => unitOfWork.OrderRepository.Update(mapper.Map<Order>(model)));
        }
    }
}
