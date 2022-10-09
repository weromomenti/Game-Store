using Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data_Layer.Data
{
    public class GameStoreDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PEGIRating> PEGIRatings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIdentity> UserIdentities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, GenreName = "Genre1" },
                new Genre { Id = 2, GenreName = "Genre2" });
            builder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "The Witcher 3: Wild Hunt", Description = "Description", PEGIRatingId = 1, ImageUrl = "https://picfiles.alphacoders.com/198/thumb-198636.jpg", Price = 30m },
                new Game { Id = 2, Name = "Battlefield V", Description = "Description", PEGIRatingId = 2, ImageUrl = "https://m.media-amazon.com/images/I/515XvAG+q6L._AC_SY780_.jpg", Price = 40m });            
            builder.Entity<PEGIRating>().HasData(
                new PEGIRating { Id = 1, Name = "PEGI1" },
                new PEGIRating { Id = 2, Name = "PEGI2" });
            builder.Entity<UserIdentity>().HasData(
                new UserIdentity { UserName = "Admin", PasswordHash = "Admin" });
            builder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "User" });
        }
    }
}
