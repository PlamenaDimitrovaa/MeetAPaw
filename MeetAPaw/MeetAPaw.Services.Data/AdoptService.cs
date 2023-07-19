
using MeetAPaw.Data;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class AdoptService : IAdoptService
    {
        private readonly MeetAPawDbContext context;

        public AdoptService(MeetAPawDbContext contex)
        {
            this.context = contex;
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetPetsForAdoptionAsync()
        {
            return await context.PetsForAdoption
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
                .Where(p => p.PetType.Name == "Dog")
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
                .Where(p => p.PetType.Name == "Cat")
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
                .Where(p => p.PetType.Name == "Bird")
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
                .Where(p => p.PetType.Name == "Rabbit")
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
    }
}
