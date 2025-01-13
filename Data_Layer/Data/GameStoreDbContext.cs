using Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Data_Layer.Entities.Configurations;

namespace Data_Layer.Data
{
    public class GameStoreDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PEGIRating> PEGIRatings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public new DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new PEGIRatingConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
