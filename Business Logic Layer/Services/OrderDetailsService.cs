using AutoMapper;
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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderDetailsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(OrderDetailsModel model)
        {
            await unitOfWork.OrderDetailsRepository.AddAsync(mapper.Map<OrderDetails>(model));
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.OrderDetailsRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<OrderDetailsModel>> GetAllAsync()
        {
            var orderDetails = await unitOfWork.OrderDetailsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OrderDetailsModel>>(orderDetails);
        }

        public async Task<OrderDetailsModel> GetByIdAsync(int id)
        {
            var orderDetails = await unitOfWork.OrderDetailsRepository.GetByIdAsync(id);
            return mapper.Map<OrderDetailsModel>(orderDetails);
        }

        public async Task UpdateAsync(OrderDetailsModel model)
        {
            await Task.Run (() => unitOfWork.OrderDetailsRepository.Update(mapper.Map<OrderDetails>(model)));
        }
    }
}
