using Data_Layer.Data;
using Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Tests
{
    internal static class UnitTestHelper
    {
        public static DbContextOptions<GameStoreDbContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<GameStoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new GameStoreDbContext(options);

            SeedData(context);

            return options;
        }
        public static void SeedData(GameStoreDbContext context)
        {
            context.Games.AddRangeAsync(
                new Game { Id = 1, Name = "Game1", Description = "Description1", PEGIRatingId = 1, ImageUrl = "Url1", Price = 30m },
                new Game { Id = 2, Name = "Game2", Description = "Description2", PEGIRatingId = 2, ImageUrl = "Url2", Price = 40m });
            context.Genres.AddRange(
                new Genre { Id = 1, GenreName = "Genre1" },
                new Genre { Id = 2, GenreName = "Genre2" });
            context.PEGIRatings.AddRange(
                new PEGIRating { Id = 1, RatingName = "PEGI1" },
                new PEGIRating { Id = 2, RatingName = "PEGI2" });
            context.Comments.AddRange(
                new Comment { Id = 1, GameId = 1, Likes = 0, Dislikes = 0, PostDate = DateTime.Today, Text = "Comment1", UserId = 1 },
                new Comment { Id = 2, GameId = 1, Likes = 1, Dislikes = 2, PostDate = DateTime.Today, Text = "Comment2", UserId = 2 });
            context.Users.AddRange(
                new User { Id = 1, Avatar = "avatar1", PersonId = 1, RoleId = 1 },
                new User { Id = 2, Avatar = "avatar2", PersonId = 2, RoleId = 2 });
            context.Identities.AddRange(
                new UserIdentity { Id = "1", Email = "Email1", UserName = "Username1", PasswordHash = "password1" },
                new UserIdentity { Id = "2", Email = "Email2", UserName = "Username2", PasswordHash = "password2" });
            context.Persons.AddRange(
                new Person { Id = 1, FirstName = "FirstName1", LastName = "lastname1", BirthDate = DateTime.Today },
                new Person { Id = 2, FirstName = "FirstName2", LastName = "lastname2", BirthDate = DateTime.Today });
            context.Orders.AddRange(
                new Order { Id = 1, UserId = 1, OrderDate = DateTime.Today },
                new Order { Id = 2, UserId = 2, OrderDate = DateTime.Today });
            context.OrderDetails.AddRange(
                new OrderDetails { Id = 1, GameId = 1, OrderId = 1, Quantity = 1, UnitPrice = 30m },
                new OrderDetails { Id = 2, GameId = 2, OrderId = 2, Quantity = 3, UnitPrice = 90m });
            context.SaveChanges();
        }
    }
}
