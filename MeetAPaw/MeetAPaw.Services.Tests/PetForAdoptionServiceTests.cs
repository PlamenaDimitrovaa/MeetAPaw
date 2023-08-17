using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.PetForAdoption;
using Microsoft.EntityFrameworkCore;

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

        [Test]
        [TestCase(102)]
        public async Task GetPetForAdoptionForEditByIdAsyncShouldWorkCorrect(int id)
        {
            var petForAdoption = new PetForAdoption
            {
                Name = "Test",
                PetTypeId = 1,
                Breed = "Test",
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/cute-dog-portrait-studio_23-2149016933.jpg?t=st=1691860649~exp=1691861249~hmac=174c537502bcf5364aa66fa204da6dd3420ee17208c90d58ac0bbe97127b8ad9",
                DateOfBirth = DateTime.Parse("09/08/2020"),
                Address = "Sofia, Bulgaria",
                Description = "Some description of the peet for testt==ing unit tests",
                Gender = MeetAPaw.Data.Models.Enums.PetGender.Male,
            };

            await this.data.PetsForAdoption.AddAsync(petForAdoption);
            await this.data.SaveChangesAsync();

            var result = await this.petForAdoptionService.GetPetForAdoptionForEditByIdAsync(id);

            Assert.That(result.Id, Is.EqualTo(petForAdoption.Id));
        }

        [Test]
        [TestCase(101)]
        public async Task EditPetForAdoptionByIdAsyncMethodShouldEditPetCorrectly(int id)
        {
            var newName = "Jerry";
            var pet = await this.petForAdoptionService.GetPetForAdoptionForEditByIdAsync(id);
            pet.Name = newName;

            await this.petForAdoptionService.EditPetForAdoptionByIdAsync(id, pet);
            var result = await this.petForAdoptionService.GetPetForAdoptionByIdAsync(id);

            Assert.That(result.Name, Is.EqualTo(newName));
        }

        [Test]
        [TestCase(10)]
        public async Task PetForAdoptionExistsByIdAsyncShouldReturnTrue(int id)
        {
            bool result = await this.data.PetsForAdoption
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(1000000000)]
        public async Task PetForAdoptionExistsByIdAsyncShouldReturnFalse(int id)
        {
            bool result = await this.data.PetsForAdoption
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.False);
        }
        
        [Test]
        [TestCase(10)]
        public async Task DeletePetForAdoptionByIdAsync(int id)
        {
            await this.petForAdoptionService.DeletePetForAdoptionByIdAsync(id);
            var pet = await this.petForAdoptionService.GetPetForAdoptionByIdAsync(id);

            Assert.IsNull(pet);
        }
    }
}
