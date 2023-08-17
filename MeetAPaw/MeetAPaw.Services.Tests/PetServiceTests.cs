using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Tests
{
    [TestFixture]
    public class PetServiceTests : UnitTestsBase
    {
        private IPetService petService;

        [SetUp]
        public void Setup()
        {
            this.petService = new PetService(this.data);
        }

        [Test]
        public async Task AddPetAsyncMethodShouldAddPetCorrectly()
        {
            var petModel = new AddPetViewModel()
            {
                Id = 130,
                Name = "Test",
                PetTypeId = 1,
                Breed = "Test breed",
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/chihuahua-cute-pet-lovely-animal-cap-concept_53876-65101.jpg?w=996&t=st=1688976253~exp=1688976853~hmac=6cf748d837e8c94d718ff937d582bd777adf75521da98181da10ab93681d35d5",
                DateOfBirth = "11/11/2023",
                Address = "Blagoevgrad, Bulgaria",
                Description = "Incredible dog with a lot of charm and cute vision.",
                Gender = "Male",
            };

            var petId = await this.petService.AddPetAsync(petModel, this.User.Id.ToString());
            var pet = await this.petService.GetPetByIdAsync(petId);

            Assert.NotNull(pet);
            Assert.IsNotNull(pet);
        }

        [Test]
        public async Task GetAllPetsAsyncShouldReturnAllPetsCorrectly()
        {
            var pets = await this.petService.GetAllPetsAsync();

            Assert.That(pets.Count(), Is.EqualTo(5));
        }

        [Test]
        [TestCase(101)]
        public async Task GetPetForEditByIdAsyncShouldReturnPetCorrectly(int id)
        {
            var pet = new Pet
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
                OwnerId = Guid.Parse("7D8C975B-6482-4C8C-AF23-9D6E453C8998")
            };

            await this.data.Pets.AddAsync(pet);
            await this.data.SaveChangesAsync();

            var result = await this.petService.GetPetForEditByIdAsync(id);
            
            Assert.That(result.Id, Is.EqualTo(pet.Id)); 
        }

        [Test]
        [TestCase(100)]
        public async Task EditPetByIdAsyncMethodShouldEditPetCorrectly(int id)
        {
            var newName = "Jerry";
            var pet = await this.petService.GetPetForEditByIdAsync(id);
            pet.Name = newName;

            await this.petService.EditPetByIdAsync(id, pet);
            var result = await this.petService.GetPetByIdAsync(id);

            Assert.That(result.Name, Is.EqualTo(newName));
        }

        [Test]
        [TestCase(1)]
        public async Task PetExistsByIdAsyncShouldReturnTrue(int id)
        {
            bool result = await this.data.Pets
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(10000)]
        public async Task PetExistsByIdAsyncShouldReturnFalse(int id)
        {
            bool result = await this.data.Pets
                .AnyAsync(p => p.Id == id);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(100)]
        public async Task DeletePetByIdAsyncShouldDeleteSuccessfully(int id)
        {
            await this.petService.DeletePetByIdAsync(id);
            var pet = await this.petService.GetPetByIdAsync(id);

            Assert.IsNull(pet);
        }
    }
}