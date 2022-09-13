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
    internal class GenreRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task GenreRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var genreRepository = new GenreRepository(context);

            var actual = await genreRepository.GetByIdAsync(id);
            var expected = ExpectedGenres.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new GenreComparer()));
        }
        [Test]
        public async Task GenreRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var genreRepository = new GenreRepository(context);

            var actual = await genreRepository.GetAllAsync();
            var expected = ExpectedGenres;

            Assert.That(actual, Is.EqualTo(expected).Using(new GenreComparer()));
        }
        [Test]
        public async Task GenreRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var GenreRepository = new GenreRepository(context);

            var prevCount = context.Genres.Count();
            var newGame = new Genre { Id = 3, GenreName = "NewGenreName" };

            await GenreRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Genres.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task GenreRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var GenreRepository = new GenreRepository(context);

            var prevCount = context.Genres.Count();

            await GenreRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Genres.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task GenreRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var genreRepository = new GenreRepository(context);

            var newGenre = new Genre
            {
                Id = 1,
                GenreName = "UpdatedGenreName",
            };
            genreRepository.Update(newGenre);
            await context.SaveChangesAsync();

            var updatedGenre = await genreRepository.GetByIdAsync(1);

            Assert.That(newGenre, Is.EqualTo(updatedGenre).Using(new GenreComparer()));
        }

        private static IEnumerable<Genre> ExpectedGenres => new[]
        {
            new Genre { Id = 1, GenreName = "Genre1" },
            new Genre { Id = 2, GenreName = "Genre2" }
        };
    }
}
