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
    internal class CartRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task CartRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var cartRepository = new CartRepository(context);

            var actual = await cartRepository.GetByIdAsync(id);
            var expected = ExpectedCarts.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new CartComparer()));
        }
        [Test]
        public async Task CartRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var cartRepository = new CartRepository(context);

            var actual = await cartRepository.GetAllAsync();
            var expected = ExpectedCarts;

            Assert.That(actual, Is.EqualTo(expected).Using(new CartComparer()));
        }
        [Test]
        public async Task CartRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var cartRepository = new CartRepository(context);

            var prevCount = context.Carts.Count();
            var newGame = new Cart { Id = 3 };

            await cartRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Carts.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task CartRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var cartRepository = new CartRepository(context);

            var prevCount = context.Carts.Count();

            await cartRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Carts.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task CartRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var cartRepository = new CartRepository(context);

            var newCart = new Cart
            {
                Id = 1,
                UserId = 1, 
                TotalPrice = 20
            };
            cartRepository.Update(newCart);
            await context.SaveChangesAsync();

            var updatedCart = await cartRepository.GetByIdAsync(1);

            Assert.That(newCart, Is.EqualTo(updatedCart).Using(new CartComparer()));
        }
        private static IEnumerable<Cart> ExpectedCarts => new[]
        {
            new Cart { Id = 1, UserId = 1, TotalPrice = 20m, IsCheckedOut = false },
            new Cart { Id = 2, UserId = 2, TotalPrice = 30m, IsCheckedOut = true }
        };
    }
}
