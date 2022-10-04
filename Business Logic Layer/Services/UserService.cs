using AutoMapper;
using Business_Logic_Layer.Infrastructure.Validators;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserValidator userValidator;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userValidator = new UserValidator();
        }
        public Task AddAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await unitOfWork.UserRepository.GetAllWithDetailsAync();

            return mapper.Map<IEnumerable<UserModel>>(users);
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            var user = await unitOfWork.UserRepository.GetByUserNameAsync(userName);
            return user;
        }
        public Task<UserModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRoleAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
