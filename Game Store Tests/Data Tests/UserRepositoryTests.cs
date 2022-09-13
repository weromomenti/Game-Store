using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using Data_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Tests.Data_Tests
{
    internal class UserRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task UserRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userRepository = new UserRepository(context);

            var actual = await userRepository.GetByIdAsync(id);
            var expected = ExpectedUsers.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new UserComparer()));
        }
        [Test]
        public async Task UserRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userRepository = new UserRepository(context);

            var actual = await userRepository.GetAllAsync();
            var expected = ExpectedUsers;

            Assert.That(actual, Is.EqualTo(expected).Using(new UserComparer()));
        }
        [Test]
        public async Task UserRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userRepository = new UserRepository(context);

            var prevCount = context.Users.Count();
            var newGame = new User { Id = 3, UserName = "NewUserName", Email = "NewEmail", Password = "NewPassword", Avatar = "NewAvatar" };

            await userRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Users.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task UserRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userRepository = new UserRepository(context);

            var prevCount = context.Users.Count();

            await userRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Users.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task UserRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var userRepository = new UserRepository(context);

            var newUser = new User
            {
                Id = 1,
                UserName = "UpdatedUserName1"
            };
            userRepository.Update(newUser);
            await context.SaveChangesAsync();

            var updatedUser = await userRepository.GetByIdAsync(1);

            Assert.That(newUser, Is.EqualTo(updatedUser).Using(new UserComparer()));
        }
        private static IEnumerable<User> ExpectedUsers => new[]
        {
            new User { Id = 1, UserName = "User1", Email = "Email1", Password = "password1", Avatar = "avatar1", PersonId = 1, RoleId = 1 },
            new User { Id = 2, UserName = "User2", Email = "Email2", Password = "password2", Avatar = "avatar2", PersonId = 2, RoleId = 2 }
        };
    }
}
