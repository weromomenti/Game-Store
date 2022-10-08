using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Data_Layer.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Tests.Data_Tests
{
    internal class RoleRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task RoleRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var roleRepository = new RoleRepository(context);

            var actual = await roleRepository.GetByIdAsync(id);
            var expected = ExpectedRoles.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new RoleComparer()));
        }
        [Test]
        public async Task RoleRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var roleRepository = new RoleRepository(context);

            var actual = await roleRepository.GetAllAsync();
            var expected = ExpectedRoles;

            Assert.That(actual, Is.EqualTo(expected).Using(new RoleComparer()));
        }
        [Test]
        public async Task RoleRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var roleRepository = new RoleRepository(context);

            var prevCount = context.Roles.Count();
            var newGame = new Role { Id = 3, RoleIdentity =new IdentityRole("NewRoleName") };

            await roleRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Roles.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task RoleRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var roleRepository = new RoleRepository(context);

            var prevCount = context.Roles.Count();

            await roleRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Roles.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task RoleRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var roleRepository = new RoleRepository(context);

            var newRole = new Role
            {
                Id = 1,
                RoleIdentity = new IdentityRole("UpdatedRole")
            };
            roleRepository.Update(newRole);
            await context.SaveChangesAsync();

            var updatedRole = await roleRepository.GetByIdAsync(1);

            Assert.That(newRole, Is.EqualTo(updatedRole).Using(new RoleComparer()));
        }
        private static IEnumerable<Role> ExpectedRoles => new[]
        {
            new Role { Id = 1, RoleIdentity = new IdentityRole("User")},
            new Role { Id = 2, RoleIdentity = new IdentityRole("Manager")}
        };
    }
}
