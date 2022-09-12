using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameModel>()
                .ForMember(gm => gm.Id, x => x.MapFrom(g => g.Id))
                .ForMember(gm => gm.Name, x => x.MapFrom(g => g.Name))
                .ForMember(gm => gm.Price, x => x.MapFrom(g => g.Price))
                .ForMember(gm => gm.GenreIds, x => x.MapFrom(g => g.Genres.Select(g => g.Id)))
                .ForMember(gm => gm.Description, x => x.MapFrom(g => g.Description))
                .ForMember(gm => gm.PEGIRatingID, x => x.MapFrom(g => g.PEGIRatingId))
                .ForMember(gm => gm.CommentIds, x => x.MapFrom(g => g.Comments.Select(c => c.Id)))
                .ForMember(gm => gm.Image, x => x.MapFrom(g => g.ImageUrl))
                .ReverseMap();
            CreateMap<Genre, GenreModel>()
                .ForMember(gm => gm.Id, x => x.MapFrom(g => g.Id))
                .ForMember(gm => gm.GenreName, x => x.MapFrom(g => g.GenreName))
                .ReverseMap();
            CreateMap<PEGIRating, PEGIRatingModel>()
                .ForMember(pm => pm.Id, x => x.MapFrom(p => p.Id))
                .ForMember(pm => pm.RatingName, x => x.MapFrom(p => p.Name))
                .ReverseMap();
            CreateMap<Comment, CommentModel>()
                .ForMember(cm => cm.Id, x => x.MapFrom(c => c.Id))
                .ForMember(cm => cm.UserId, x => x.MapFrom(c => c.UserId))
                .ForMember(cm => cm.GameId, x => x.MapFrom(c => c.GameId))
                .ForMember(cm => cm.Text, x => x.MapFrom(c => c.Text))
                .ForMember(cm => cm.Created, x => x.MapFrom(c => c.PostDate))
                .ForMember(cm => cm.Likes, x => x.MapFrom(c => c.Likes))
                .ForMember(cm => cm.Dislikes, x => x.MapFrom(c => c.Dislikes))
                .ForMember(cm => cm.ReplyIds, x => x.MapFrom(c => c.Replies.Select(r => r.Id)))
                .ReverseMap();
            CreateMap<User, UserModel>()
                .ForMember(um => um.Id, x => x.MapFrom(u => u.Id))
                .ForMember(um => um.RoleId, x => x.MapFrom(u => u.RoleId))
                .ForMember(um => um.CartId, x => x.MapFrom(u => u.Cart.Id))
                .ForMember(um => um.FirstName, x => x.MapFrom(u => u.Person.FirstName))
                .ForMember(um => um.LastName, x => x.MapFrom(u => u.Person.LastName))
                .ForMember(um => um.Password, x => x.MapFrom(u => u.Password))
                .ForMember(um => um.Email, x => x.MapFrom(u => u.Email))
                .ForMember(um => um.Avatar, x => x.MapFrom(u => u.Avatar))
                .ReverseMap();
            CreateMap<Role, RoleModel>()
                .ForMember(rm => rm.Id, x => x.MapFrom(r => r.Id))
                .ForMember(rm => rm.RoleName, x => x.MapFrom(r => r.RoleName))
                .ReverseMap();
            CreateMap<Cart, CartModel>()
                .ForMember(cm => cm.Id, x => x.MapFrom(c => c.Id))
                .ForMember(cm => cm.TotalPrice, x => x.MapFrom(c => c.TotalPrice))
                .ForMember(cm => cm.IsCheckedOut, x => x.MapFrom(c => c.IsCheckedOut))
                .ForMember(cm => cm.GameIds, x => x.MapFrom(c => c.Games.Select(g => g.Id)))
                .ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsModel>().ReverseMap();
        }
    }
}
