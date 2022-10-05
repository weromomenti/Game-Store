using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameModel>()
                .ForMember(gm => gm.GenreIds, x => x.MapFrom(g => g.Genres.Select(g => g.Id)))
                .ForMember(gm => gm.CommentIds, x => x.MapFrom(g => g.Comments.Select(c => c.Id)))
                .ReverseMap();
            CreateMap<Genre, GenreModel>()
                .ReverseMap();
            CreateMap<PEGIRating, PEGIRatingModel>()
                .ReverseMap();
            CreateMap<Comment, CommentModel>()
                .ForMember(cm => cm.ReplyIds, x => x.MapFrom(c => c.Replies.Select(r => r.Id)))
                .ReverseMap();
            CreateMap<User, UserModel>()
                .ForMember(um => um.FirstName, x => x.MapFrom(u => u.Person.FirstName))
                .ForMember(um => um.LastName, x => x.MapFrom(u => u.Person.LastName))
                .ForMember(um => um.Password, x => x.MapFrom(u => u.PasswordHash))
                .ReverseMap();
            CreateMap<Role, RoleModel>()
                .ReverseMap();
            CreateMap<Order, OrderModel>()
                .ReverseMap();
            CreateMap<OrderDetails, OrderDetailsModel>()
                .ReverseMap();
        }
    }
}
