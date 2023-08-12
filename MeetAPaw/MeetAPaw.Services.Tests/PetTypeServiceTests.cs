
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Tests
{
    public class PetTypeServiceTests : UnitTestsBase
    {
        private IPetTypeService petTypeService;

        [SetUp]
        public void SetUp()
        {
            this.petTypeService = new PetTypeService(this.data);
        }

        [Test]
        public async Task AllPetsTypesAsyncMethodShouldReturnCorrectPetTypes()
        {
            var petTypes = await this.petTypeService.AllPetTypesAsync();

            Assert.That(petTypes.Count(), Is.EqualTo(5));
        }

        [Test]
        public async Task AllPetsTypesNamesAsyncShouldReturnCorrectAnswer()
        {
            var petTypesNames = await this.petTypeService.AllPetsTypesNamesAsync();
            List<string> strings = new List<string>()
            {
                "Dog",
                "Cat",
                "Bird",
                "Rabbit",
                "testPetType"
            };
            Assert.That(petTypesNames, Is.EqualTo(strings));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(10)]
        public async Task ExistsByIdAsyncShouldReturnTrue(int id)
        {
            bool result = await this.data.PetsTypes
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(10000)]
        public async Task ExistsByIdAsyncShouldReturnFalse(int id)
        {
            bool result = await this.data.PetsTypes
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.False);
        }
    }
}
