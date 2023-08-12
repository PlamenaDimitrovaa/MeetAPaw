
using MeetAPaw.Data.Models;
using MeetAPaw.Data.Models.Enums;
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.PetForAdoption;

namespace MeetAPaw.Services.Tests
{
    public class PetForAdoptionServiceTests : UnitTestsBase
    {
        private IPetForAdoptionService petForAdoptionService;

        [SetUp]
        public void Setup()
        {
            this.petForAdoptionService = new PetForAdoptionService(this.data);
        }

        [Test]
        public async Task AddPetForAdoptionAsyncMethodShouldAddPetCorrectly()
        {
            var petModel = new AddPetForAdoptionViewModel()
            {
                Id = 1,
                Name = "testPetForAdoption",
                PetTypeId = 2,
                Breed = "Persian",
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                DateOfBirth = "08/09/2023",
                Description = "testing the description of the generated pet.",
                Gender = "Female",
                IsAdopted = true,
                UserId = "84520237-AA53-4477-A543-7B10C4FD91A1",
                ShelterId = 1
            };

            var petId = await this.petForAdoptionService.AddPetForAdoptionAsync(petModel);
            var pet = await this.petForAdoptionService.GetPetForAdoptionByIdAsync(petId);
        
            Assert.NotNull(pet);
            Assert.IsNotNull(pet);
        }
    }
}
