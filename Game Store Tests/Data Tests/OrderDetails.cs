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
    internal class OrderDetailsDetails
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task OrderDetailsRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailsRepository = new OrderDetailsRepository(context);

            var actual = await orderDetailsRepository.GetByIdAsync(id);
            var expected = ExpectedOrderDetailss.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new OrderDetailsComparer()));
        }
        [Test]
        public async Task OrderDetailsRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailsRepository = new OrderDetailsRepository(context);

            var actual = await orderDetailsRepository.GetAllAsync();
            var expected = ExpectedOrderDetailss;

            Assert.That(actual, Is.EqualTo(expected).Using(new OrderDetailsComparer()));
        }
        [Test]
        public async Task OrderDetailsRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailsRepository = new OrderDetailsRepository(context);

            var prevCount = context.OrderDetails.Count();
            var newGame = new OrderDetails { Id = 3 };

            await orderDetailsRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.OrderDetails.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task OrderDetailsRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailsRepository = new OrderDetailsRepository(context);

            var prevCount = context.OrderDetails.Count();

            await orderDetailsRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.OrderDetails.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task OrderDetailsRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailsRepository = new OrderDetailsRepository(context);

            var newOrderDetails = new OrderDetails
            {
                Id = 1,
                Quantity = 3, 
                GameId = 2
            };
            orderDetailsRepository.Update(newOrderDetails);
            await context.SaveChangesAsync();

            var updatedGenre = await orderDetailsRepository.GetByIdAsync(1);

            Assert.That(newOrderDetails, Is.EqualTo(updatedGenre).Using(new OrderDetailsComparer()));
        }
        private static IEnumerable<OrderDetails> ExpectedOrderDetailss => new[]
        {
            new OrderDetails { Id = 1, GameId = 1, OrderId = 1, Quantity = 1, UnitPrice = 30m },
            new OrderDetails { Id = 2, GameId = 2, OrderId = 2, Quantity = 3, UnitPrice = 90m }
        };
    }
}
