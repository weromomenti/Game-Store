using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Repositories;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Tests.Data_Tests
{
    [TestFixture]
    internal class GameRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task GameRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var gameRepository = new GameRepository(context);

            var actual = await gameRepository.GetByIdAsync(id);
            var expected = ExpectedGames.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new GameEqualityComparer()));
        }
        [Test]
        public async Task GameRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var gameRepository = new GameRepository(context);

            var actual = await gameRepository.GetAllAsync();
            var expected = ExpectedGames;

            Assert.That(actual, Is.EqualTo(expected).Using(new GameEqualityComparer()));
        }
        [Test]
        public async Task GameRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var gameRepository = new GameRepository(context);

            var prevCount = context.Games.Count();
            var newGame = new Game { Id = 3, Name = "NewName", ImageUrl = "NewImageUrl", Description = "NewDescription" };

            await gameRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Games.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task GameRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var gameRepository = new GameRepository(context);

            var prevCount = context.Games.Count();

            await gameRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Games.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task GameRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var gameRepository = new GameRepository(context);

            var newGame = new Game
            {
                Id = 1,
                Name = "UpdatedGameName",
                Price = 40m,
                Description = "UpdatedDescription"
            };
            gameRepository.Update(newGame);
            await context.SaveChangesAsync();

            var updatedGame = await gameRepository.GetByIdAsync(1);


            Assert.That(newGame, Is.EqualTo(updatedGame).Using(new GameEqualityComparer()));
        }
        [TestCase(1)]
        public async Task GameRepository_GetByIdWithDetailsAsync(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var gameRepository = new GameRepository(context);

            var actualWithDetails = gameRepository.GetByIdWithDetailsAsync(id);
            var expectedWithDetails = ExpectedGames.FirstOrDefault(g => g.Id == id);

            Assert.That(actualWithDetails, Is.EqualTo(expectedWithDetails).Using(new GameEqualityComparer()));

            //Assert.That(actualWithDetails.peg)
        }




        private static IEnumerable<Game> ExpectedGames => new[]
        {
            new Game { Id = 1, Name = "Game1", Description = "Description1", PEGIRatingId = 1, ImageUrl = "Url1", Price = 30m },
            new Game { Id = 2, Name = "Game2", Description = "Description2", PEGIRatingId = 2, ImageUrl = "Url2", Price = 40m }
        };
        private static IEnumerable<PEGIRating> ExpectedPEGIRatings => new[]
        {
            new PEGIRating {Id = 1, Name = "PEGI1" },
            new PEGIRating {Id = 2, Name = "PEGI2"}
        };
    }
}
