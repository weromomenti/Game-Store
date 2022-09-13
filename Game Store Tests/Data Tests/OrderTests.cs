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
    internal class OrderTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task OrderRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderRepository = new OrderRepository(context);

            var actual = await orderRepository.GetByIdAsync(id);
            var expected = ExpectedOrders.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new OrderComparer()));
        }
        [Test]
        public async Task OrderRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderRepository = new OrderRepository(context);

            var actual = await orderRepository.GetAllAsync();
            var expected = ExpectedOrders;

            Assert.That(actual, Is.EqualTo(expected).Using(new OrderComparer()));
        }
        [Test]
        public async Task OrderRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderRepository = new OrderRepository(context);

            var prevCount = context.Orders.Count();
            var newGame = new Order { Id = 3 };

            await orderRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Orders.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task OrderRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderRepository = new OrderRepository(context);

            var prevCount = context.Orders.Count();

            await orderRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Orders.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task OrderRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderRepository = new OrderRepository(context);

            var newOrder = new Order
            {
                Id = 1, 
                UserId = 1
            };
            orderRepository.Update(newOrder);
            await context.SaveChangesAsync();

            var updatedOrder = await orderRepository.GetByIdAsync(1);

            Assert.That(newOrder, Is.EqualTo(updatedOrder).Using(new OrderComparer()));
        }
        private static IEnumerable<Order> ExpectedOrders => new[]
        {
            new Order { Id = 1, UserId = 1, OrderDate = DateTime.Today },
            new Order { Id = 2, UserId = 2, OrderDate = DateTime.Today }
        };
    }
}
