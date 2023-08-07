
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Services.Data.Models.AdoptPet;
using MeetAPaw.Services.Data.Models.Pet;
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class AdoptService : IAdoptService
    {
        private readonly MeetAPawDbContext context;

        public AdoptService(MeetAPawDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetPetsForAdoptionAsync()
        {
            return await context.PetsForAdoption
                .Where(p => p.IsAdopted == false)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetDogsForAdoptionAsync()
        {
            return await context.PetsForAdoption
                .Where(p => p.PetType.Name == "Dog" && p.IsAdopted == false)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetCatsForAdoptionAsync()
        {
            return await context.PetsForAdoption
                .Where(p => p.PetType.Name == "Cat" && p.IsAdopted == false)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetBirdsForAdoptionAsync()
        {
            return await context.PetsForAdoption
                .Where(p => p.PetType.Name == "Bird" && p.IsAdopted == false)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetRabbitsForAdoptionAsync()
        {
            return await context.PetsForAdoption
                .Where(p => p.PetType.Name == "Rabbit" && p.IsAdopted == false)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .ToListAsync();
        }

        public async Task<PetForAdoption?> GetPetForAdoptionAsync(int petId)
        {
            var petForAdoption = await context.PetsForAdoption
                            .Include(p => p.User)
                            .FirstOrDefaultAsync(p => p.Id == petId && p.IsAdopted == false);

            return petForAdoption;
        }

        public async Task UpdatePetForAdoptionAsync(PetForAdoption petForAdoption, string adopterId)
        {
            petForAdoption.IsAdopted = true;
            petForAdoption.AdopterId = Guid.Parse(adopterId);

            context.PetsForAdoption.Update(petForAdoption);
        }

        public async Task<AdoptPetViewModel?> GetPetForAdoptionByIdAsync(int id)
        {
            return await this.context.PetsForAdoption
                .Where(p => p.Id == id)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    Description = p.Description,
                    Color = p.Color,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString("yyyy/MM/dd"),
                    PetType = p.PetType.Name,
                    PetTypeId = p.PetTypeId,
                    Breed = p.Breed,
                    Shelter = p.Shelter.Name,
                    IsAdopted = p.IsAdopted,
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAdoption(string adopterId, PetForAdoption petForAdoption)
        {
            var adoption = new Adoption
            {
                AdopterId = Guid.Parse(adopterId),
                PetForAdoptionId = petForAdoption.Id,
                Date = DateTime.UtcNow,
                ShelterId = petForAdoption.ShelterId
            };

            await this.context.Adoptions.AddAsync(adoption);
            await context.SaveChangesAsync();
        }

        public async Task<AllPetsForAdoptionFilteredAndPagesServiceModel> AllAsync(AllPetsForAdoptionQueryModel queryModel)
        {
            IQueryable<PetForAdoption> petsQuery = this.context
                .PetsForAdoption
                .AsQueryable();


            if (queryModel.PetType != "All" && queryModel.PetType != null)
            {
                petsQuery = petsQuery
                    .Where(p => p.PetType.Name == queryModel.PetType);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                petsQuery = petsQuery
                    .Where(p => EF.Functions.Like(p.Name, wildCard) ||
                                EF.Functions.Like(p.Description, wildCard) ||
                                EF.Functions.Like(p.Breed, wildCard) ||
                                EF.Functions.Like(p.PetType.Name, wildCard));
            }

            var allPets = await petsQuery
                .Where(p => p.IsAdopted == false)
                .Skip((queryModel.CurrentPage - 1) * queryModel.PetsPerPage)
                .Take(queryModel.PetsPerPage)
                .Select(p => new AdoptPetViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    Description = p.Description,
                    Color = p.Color,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed,
                    Shelter = p.Shelter.Name,
                    IsAdopted = p.IsAdopted
                })
                .ToListAsync();

            int totalPets = petsQuery.Count();

            return new AllPetsForAdoptionFilteredAndPagesServiceModel()
            {
                TotalPetsCount = totalPets,
                Pets = allPets
            };
        }
    }
}
