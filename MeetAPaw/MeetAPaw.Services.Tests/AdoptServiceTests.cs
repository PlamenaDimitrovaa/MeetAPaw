using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Services.Data;
using MeetAPaw.Data.Models;

namespace MeetAPaw.Services.Tests
{
    public class AdoptServiceTests : UnitTestsBase
    {
        private IAdoptService adoptService;

        [SetUp]
        public void Setup()
        {
            this.adoptService = new AdoptService(this.data);
        }

        [Test]
        public async Task GetPetsForAdoptionAsyncShouldReturnTheCorrectResult()
        {
            await this.data.PetsForAdoption.AddRangeAsync(new List<PetForAdoption>
            {
                new PetForAdoption
                {
                     Id = 122,
                    Name = "test",
                    PetTypeId = 1,
                    Breed = "Persian",
                    Color = "White",
                    ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                    DateOfBirth = DateTime.Parse("08/09/2023"),
                    Address = "Sofia, Bulgaria",
                    Description = "testing the description of the generated pet.",
                    Gender = MeetAPaw.Data.Models.Enums.PetGender.Female,
                }
            });

            await this.data.SaveChangesAsync();

            var petsForAdoption = await this.adoptService.GetPetsForAdoptionAsync();

            Assert.That(petsForAdoption.Count(), Is.EqualTo(7));
        }

        [Test]
        public async Task GetDogsForAdoptionAsyncShouldReturnOnlyTheDogsAvailableFForAdoption()
        {
            await this.data.PetsForAdoption.AddRangeAsync(new List<PetForAdoption>
            {
                new PetForAdoption
                {
                     Id = 123,
                    Name = "test",
                    PetTypeId = 1,
                    Breed = "",
                    Color = "White",
                    ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                    DateOfBirth = DateTime.Parse("08/09/2023"),
                    Address = "Sofia, Bulgaria",
                    Description = "testing the description of the generated pet.",
                    Gender = MeetAPaw.Data.Models.Enums.PetGender.Female,
                }
            });

            await this.data.SaveChangesAsync();

            var petsForAdoption = await this.adoptService.GetDogsForAdoptionAsync();

            Assert.That(petsForAdoption.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetCatsForAdoptionAsyncShouldReturnOnlyTheDogsAvailableFForAdoption()
        {
            await this.data.PetsForAdoption.AddRangeAsync(new List<PetForAdoption>
            {
                new PetForAdoption
                {
                     Id = 124,
                    Name = "test",
                    PetTypeId = 2,
                    Breed = "",
                    Color = "White",
                    ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                    DateOfBirth = DateTime.Parse("08/09/2023"),
                    Address = "Sofia, Bulgaria",
                    Description = "testing the description of the generated pet.",
                    Gender = MeetAPaw.Data.Models.Enums.PetGender.Female,
                }
            });

            await this.data.SaveChangesAsync();

            var petsForAdoption = await this.adoptService.GetCatsForAdoptionAsync();

            Assert.That(petsForAdoption.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task GetBirdsForAdoptionAsyncShouldReturnOnlyTheDogsAvailableFForAdoption()
        {
            await this.data.PetsForAdoption.AddRangeAsync(new List<PetForAdoption>
            {
                new PetForAdoption
                {
                     Id = 125,
                    Name = "test",
                    PetTypeId = 3,
                    Breed = "",
                    Color = "White",
                    ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                    DateOfBirth = DateTime.Parse("08/09/2023"),
                    Address = "Sofia, Bulgaria",
                    Description = "testing the description of the generated pet.",
                    Gender = MeetAPaw.Data.Models.Enums.PetGender.Female,
                }
            });

            await this.data.SaveChangesAsync();

            var petsForAdoption = await this.adoptService.GetBirdsForAdoptionAsync();

            Assert.That(petsForAdoption.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetRabbitsForAdoptionAsyncShouldReturnOnlyTheDogsAvailableFForAdoption()
        {
            await this.data.PetsForAdoption.AddRangeAsync(new List<PetForAdoption>
            {
                new PetForAdoption
                {
                     Id = 125,
                    Name = "test",
                    PetTypeId = 4,
                    Breed = "",
                    Color = "White",
                    ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                    DateOfBirth = DateTime.Parse("08/09/2023"),
                    Address = "Sofia, Bulgaria",
                    Description = "testing the description of the generated pet.",
                    Gender = MeetAPaw.Data.Models.Enums.PetGender.Female,
                }
            });

            await this.data.SaveChangesAsync();

            var petsForAdoption = await this.adoptService.GetRabbitsForAdoptionAsync();

            Assert.That(petsForAdoption.Count(), Is.EqualTo(2));
        }
    }
}
