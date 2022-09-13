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
    internal class PEGIRatingRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task PEGIRatingRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var PEGIRatingRepository = new PEGIRatingRepository(context);

            var actual = await PEGIRatingRepository.GetByIdAsync(id);
            var expected = ExpectedPEGIRatings.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new PEGIRatingComparer()));
        }
        [Test]
        public async Task PEGIRatingRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var PEGIRatingRepository = new PEGIRatingRepository(context);

            var actual = await PEGIRatingRepository.GetAllAsync();
            var expected = ExpectedPEGIRatings;

            Assert.That(actual, Is.EqualTo(expected).Using(new PEGIRatingComparer()));
        }
        [Test]
        public async Task PEGIRatingRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var PEGIRatingRepository = new PEGIRatingRepository(context);

            var prevCount = context.PEGIRatings.Count();
            var newGame = new PEGIRating { Id = 3, Name = "NewName" };

            await PEGIRatingRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.PEGIRatings.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task PEGIRatingRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var PEGIRatingRepository = new PEGIRatingRepository(context);

            var prevCount = context.PEGIRatings.Count();

            await PEGIRatingRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.PEGIRatings.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task PEGIRatingRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var PEGIRatingRepository = new PEGIRatingRepository(context);

            var newPEGIRating = new PEGIRating
            {
                Id = 1,
                Name = "UpdatedPEGIRatingName",
            };
            PEGIRatingRepository.Update(newPEGIRating);
            await context.SaveChangesAsync();

            var updatedPEGIRating = await PEGIRatingRepository.GetByIdAsync(1);

            Assert.That(newPEGIRating, Is.EqualTo(updatedPEGIRating).Using(new PEGIRatingComparer()));
        }

        private static IEnumerable<PEGIRating> ExpectedPEGIRatings => new[]
        {
            new PEGIRating { Id = 1, Name = "PEGI1" },
            new PEGIRating { Id = 2, Name = "PEGI2" }
        };
    }
}
