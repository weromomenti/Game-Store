using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Repositories;
using System.Globalization;

namespace GameStoreTests
{
    [TestClass]
    public class GameRepositoryTests
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly GameRepository gameRepository;

        public GameRepositoryTests()
        {
            _dbContext = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());
            gameRepository = new GameRepository(_dbContext);
        }

        [TestMethod]
        public async Task GameRepository_GetAllAsync_ReturnsAllValues()
        {
            var games = await gameRepository.GetAllAsync();

            var expecteds = ExpectedGames;

            Assert.AreEqual(expecteds, games);
        }
        private IEnumerable<Game> ExpectedGames => new[] {
            new Game { Id = 1, Name = "Game1", Description = "Description1", PEGIRatingId = 1, ImageUrl = "Url1", Price = 30m },
            new Game { Id = 2, Name = "Game2", Description = "Description2", PEGIRatingId = 2, ImageUrl = "Url2", Price = 40m } };
    }
}