using Data_Layer.Data;
using Data_Layer.Entities;
using Data_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Tests.Data_Tests
{
    internal class PersonRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task PersonRepository_GetIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var personRepository = new PersonRepository(context);

            var actual = await personRepository.GetByIdAsync(id);
            var expected = ExpectedPersons.FirstOrDefault(x => x.Id == id);

            Assert.That(actual, Is.EqualTo(expected).Using(new PersonComparer()));
        }
        [Test]
        public async Task PersonRepository_GetAllAsync_ReturnsAllGames()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var personRepository = new PersonRepository(context);

            var actual = await personRepository.GetAllAsync();
            var expected = ExpectedPersons;

            Assert.That(actual, Is.EqualTo(expected).Using(new PersonComparer()));
        }
        [Test]
        public async Task PersonRepository_AddAsync_AddsGameToDB()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var personRepository = new PersonRepository(context);

            var prevCount = context.Persons.Count();
            var newGame = new Person { Id = 3, FirstName = "NewFirstName", LastName = "NewLastName" };

            await personRepository.AddAsync(newGame);
            await context.SaveChangesAsync();

            Assert.That(context.Persons.Count(), Is.EqualTo(prevCount + 1));
        }
        [TestCase(1)]
        public async Task PersonRepository_DeleteByIdAsync_DeletesGameFromDB(int id)
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var personRepository = new PersonRepository(context);

            var prevCount = context.Persons.Count();

            await personRepository.DeleteByIdAsync(id);
            await context.SaveChangesAsync();

            Assert.That(context.Persons.Count(), Is.EqualTo(prevCount - 1));
        }
        [Test]
        public async Task PersonRepository_Update_UpdatesGameName()
        {
            using var context = new GameStoreDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var personRepository = new PersonRepository(context);

            var newPerson = new Person
            {
                Id = 1,
                FirstName = "UpdatedPersonName1"
            };
            personRepository.Update(newPerson);
            await context.SaveChangesAsync();

            var updatedPerson = await personRepository.GetByIdAsync(1);

            Assert.That(newPerson, Is.EqualTo(updatedPerson).Using(new PersonComparer()));
        }
        private static IEnumerable<Person> ExpectedPersons => new[]
        {
            new Person { Id = 1, FirstName = "FirstName1", LastName = "lastname1", BirthDate = DateTime.Today },
            new Person { Id = 2, FirstName = "FirstName2", LastName = "lastname2", BirthDate = DateTime.Today }
        };
    }
}
