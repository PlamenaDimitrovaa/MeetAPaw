using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Tests
{
    [TestFixture]
    public class ShelterServiceTests : UnitTestsBase
    {
        private IShelterService shelterService;

        [SetUp]
        public void SetUp()
        {
            this.shelterService = new ShelterService(this.data);
        }

        [Test]
        public async Task GetAllSheltersAsyncMethodShouldReturnSheltersCorrectly()
        {
            await this.data.Shelters.AddRangeAsync(new List<Shelter>
            {
                new Shelter
                {
                     Id = 11,
                     Name = "testShelter1",
                     Address = "Sofia, Bulgaria"
                },
                 new Shelter
                {
                      Id = 12,
                     Name = "testShelter2",
                     Address = "Pleven, Bulgaria"
                },
            });

            await this.data.SaveChangesAsync();

            var shelters = await this.shelterService.AllSheltersAsync();

            Assert.That(shelters.Count(), Is.EqualTo(8));
        }

        [Test]
        [TestCase(11)]
        public async Task GetProfileAsyncShouldReturnCorrectProfile(int id)
        {
            var shelter = new Shelter()
            {
                Name = "testShelter",
                Address = "Blagoevgrad, Bulgaria"
            };

            await this.data.Shelters.AddAsync(shelter);
            await this.data.SaveChangesAsync();

            var shelters = await this.shelterService.GetProfileAsync(id);

            Assert.That(shelters.Id, Is.EqualTo(shelter.Id));
        }

        [Test]
        [TestCase(10)]
        public async Task ShelterExistsByIdAsyncShouldReturnTrue(int id)
        {
            bool result = await this.data.Shelters
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(10000)]
        public async Task ShelterExistsByIdAsyncShouldReturnFalse(int id)
        {
            bool result = await this.data.Shelters
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.False);
        }
    }
}
