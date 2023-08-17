using MeetAPaw.Data;
using MeetAPaw.Data.Models;

namespace MeetAPaw.Services.Tests
{
    public class UnitTestsBase
    {
        protected MeetAPawDbContext data;

        [SetUp]
        public async Task SetUpBase()
        {
            this.data = DatabaseMock.Instance;
            this.data.Database.EnsureDeleted();
            this.data.Database.EnsureCreated();
            await this.SeedDatabase();
        }

        public ApplicationUser User { get; set; } = null!;

        public Pet Pet { get; set; } = null!;

        public PetForAdoption PetForAdoption { get; set; } = null!;

        public Shelter Shelter { get; set; } = null!;

        private async Task SeedDatabase()
        {
            this.User = new ApplicationUser()
            {
                Id = Guid.Parse("7D8C975B-6482-4C8C-AF23-9D6E453C8998"),
                Email = "testUser@gmail.com",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
            };

            await this.data.Users.AddAsync(this.User);

            var adoption = new Adoption()
            {
                Id = 30,
                AdopterId = Guid.Parse("7D8C975B-6482-4C8C-AF23-9D6E453C8998"),
                PetForAdoptionId = 30,
                Date = DateTime.Parse("08/12/2023"),
                MoreInformation = "More information for the adoption",
                ShelterId = 3
            };

            await this.data.Adoptions.AddAsync(adoption);

            var pet = new Pet()
            {
                Id = 100,
                Name = "testPet",
                PetTypeId = 1,
                Breed = "Chihuahua",
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/view-adorable-chihuahua-dog_23-2149880026.jpg?w=996&t=st=1691799001~exp=1691799601~hmac=297430d9b51337c9dd1b527f5949bf2b96269e5a05908cd8aa8f85949e84c8d2",
                DateOfBirth = DateTime.Parse("08/09/2023"),
                Address = "Sofia, Bulgaria",
                Description = "testing the description of the generated pet.",
                Gender = MeetAPaw.Data.Models.Enums.PetGender.Male,
                OwnerId = Guid.Parse("84520237-AA53-4477-A543-7B10C4FD91A1"),
            };

            await this.data.Pets.AddAsync(pet);

            var petForAdoption = new PetForAdoption()
            {
                Id = 101,
                Name = "testPetForAdoption",
                PetTypeId = 2,
                Breed = "Persian",
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/white-cat-garden_1150-43949.jpg?w=996&t=st=1691799258~exp=1691799858~hmac=49e4a9e85d16b87e6eb7af269d4bf3e5317250f8a09034c157b336c34da9c090",
                DateOfBirth = DateTime.Parse("08/09/2023"),
                Address = "Sofia, Bulgaria",
                Description = "testing the description of the generated pet.",
                Gender = MeetAPaw.Data.Models.Enums.PetGender.Female,
            };

            await this.data.PetsForAdoption.AddAsync(petForAdoption);

            var petType = new PetType()
            {
                Id = 10,
                Name = "testPetType",
            };

            await this.data.PetsTypes.AddAsync(petType);

            var shelter = new Shelter()
            {
                Id = 10,
                Name = "testShelter",
                Address = "Blagoevgrad, Bulgaria"
            };

            await this.data.Shelters.AddAsync(shelter);

            await this.data.SaveChangesAsync();
        }

        [OneTimeTearDown]
        public void TearDownBase() => this.data.Dispose();
    }
}
