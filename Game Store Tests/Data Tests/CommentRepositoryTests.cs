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
    internal class CommentRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task CommentRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var CommentRepository = new CommentRepository(context);

            var actual = await CommentRepository.GetByIdAsync(id);
            var expected = ExpectedComments.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new CommentComparer()));
        }
        [Test]
        public async Task CommentRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var CommentRepository = new CommentRepository(context);

            var actual = await CommentRepository.GetAllAsync();
            var expected = ExpectedComments;

            Assert.That(actual, Is.EqualTo(expected).Using(new CommentComparer()));
        }
        [Test]
        public async Task CommentRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var CommentRepository = new CommentRepository(context);

            var prevCount = context.Comments.Count();
            var newGame = new Comment { Id = 3, Text = "NewText" };

            await CommentRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Comments.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task CommentRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var CommentRepository = new CommentRepository(context);

            var prevCount = context.Comments.Count();

            await CommentRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Comments.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task CommentRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var CommentRepository = new CommentRepository(context);

            var newComment = new Comment
            {
                Id = 1,
                Text = "updatedText1",
            };
            CommentRepository.Update(newComment);
            await context.SaveChangesAsync();

            var updatedComment = await CommentRepository.GetByIdAsync(1);

            Assert.That(newComment, Is.EqualTo(updatedComment).Using(new CommentComparer()));
        }
        private static IEnumerable<Comment> ExpectedComments => new[]
        {
            new Comment { Id = 1, GameId = 1, Likes = 0, Dislikes = 0, PostDate = DateTime.Today, Text = "Comment1", UserId = 1 },
            new Comment { Id = 2, GameId = 1, Likes = 1, Dislikes = 2, PostDate = DateTime.Today, Text = "Comment2", UserId = 2 }
        };
    }
}
