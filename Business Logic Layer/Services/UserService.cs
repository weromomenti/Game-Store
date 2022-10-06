using AutoMapper;
using Business_Logic_Layer.Infrastructure.Validators;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public async Task AddAsync(UserModel model)
        {
            await userValidator.ValidateAndThrowAsync(model);
            await unitOfWork.UserRepository.AddAsync(mapper.Map<User>(model));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.UserRepository.DeleteByIdAsync(modelId);
            await unitOfWork.SaveChangesAsync();
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
        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await unitOfWork.UserRepository.GetByIdAsync(id);

            return mapper.Map<UserModel>(user);
        }
        public async Task<UserModel> UpdateAsync(UserModel model)
        {
            await userValidator.ValidateAndThrowAsync(model);
            await Task.Run(() => unitOfWork.UserRepository.Update(mapper.Map<User>(model)));
            await unitOfWork.SaveChangesAsync();
            return model;
        }
    }
}
