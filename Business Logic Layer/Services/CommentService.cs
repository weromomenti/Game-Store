using AutoMapper;
using Business_Logic_Layer.Infrastructure;
using Business_Logic_Layer.Infrastructure.Validators;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly CommentValidator commentValidator;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            commentValidator = new CommentValidator();
        }
        public async Task AddAsync(CommentModel model)
        {
            await commentValidator.ValidateAndThrowAsync(model);
            await unitOfWork.CommentRepository.AddAsync(mapper.Map<Comment>(model));
            await unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.CommentRepository.DeleteByIdAsync(modelId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentModel>> GetAllAsync()
        {
            var comments = await unitOfWork.CommentRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CommentModel>>(comments);
        }

        public async Task<CommentModel> GetByIdAsync(int id)
        {
            var comment = await unitOfWork.CommentRepository.GetByIdAsync(id);
            return mapper.Map<CommentModel>(comment);
        }

        public async Task<CommentModel> ReplyCommentAsync(int id, CommentModel reply)
        {
                await commentValidator.ValidateAndThrowAsync(reply);

            var comment = await unitOfWork.CommentRepository.GetByIdAsync(id);
            if (comment.Replies == null)
            {
                comment.Replies = new List<Comment>();
            }
            comment.Replies.Add(new Comment
            {
                Game = comment.Game,
                GameId = comment.GameId,
                Dislikes = 0,
                Likes = 0,
                PostDate = reply.PostDate,
                Text = reply.Text,
                User = await unitOfWork.UserRepository.GetByIdAsync(reply.UserId),
                UserId = reply.UserId
            });
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<CommentModel>(comment);
        }

        public async Task<CommentModel> UpdateAsync(CommentModel model)
        {
            await commentValidator.ValidateAndThrowAsync(model);
            await Task.Run(() => unitOfWork.CommentRepository.Update(mapper.Map<Comment>(model)));
            await unitOfWork.SaveChangesAsync();
            return model;
        }
    }
}
