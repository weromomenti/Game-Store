using Data_Layer.Data;
using Data_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider services)
        {
            var dbContext = services.GetRequiredService<GameStoreDbContext>();
            
            if (!dbContext.Database.CanConnect())
            {
                dbContext.Database.Migrate();
                AddData(dbContext, services);
            }
        }
        public static async void AddData(GameStoreDbContext context, IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            var adminUser = await context.Users.FirstOrDefaultAsync(user => user.IdentityUser.UserName == "Admin");

            if (adminUser is null)
            {
                var Identity = new IdentityUser { UserName = "Admin", Email = "your@email.com" };

                await userManager.CreateAsync(Identity, "Admin:123");
                await userManager.AddToRoleAsync(Identity, "Admin");
            }
        }
    }
}
