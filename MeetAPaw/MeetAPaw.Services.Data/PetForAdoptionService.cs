
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Data.Models.Enums;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.PetForAdoption;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class PetForAdoptionService : IPetForAdoptionService
    {
        private readonly MeetAPawDbContext context;

        public PetForAdoptionService(MeetAPawDbContext context)
        {
            this.context = context;
        }

        public async Task AddPetForAdoptionAsync(AddPetForAdoptionViewModel model)
        {
            PetForAdoption pet = new PetForAdoption()
            {
                Id = model.Id,
                Name = model.Name,
                Breed = model.Breed,
                Description = model.Description,
                Color = model.Color,
                ImageUrl = model.ImageUrl,
                Gender = Enum.Parse<PetGender>(model.Gender),
                DateOfBirth = DateTime.Parse(model.DateOfBirth),
                PetTypeId = model.PetTypeId,
                IsAdopted = false,
                ShelterId = model.ShelterId,
                UserId = Guid.Parse(model.UserId)
            };

            await this.context.PetsForAdoption.AddAsync(pet);
            await this.context.SaveChangesAsync();
        }

        public async Task<PetForAdoptionProfileViewModel?> GetProfileToPetForAdoptionAsync(int id)
        {
            return await context.PetsForAdoption
                 .Where(p => p.Id == id)
                 .Select(p => new PetForAdoptionProfileViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Address = p.Address,
                     ImageUrl = p.ImageUrl,
                     Description = p.Description,
                     Gender = p.Gender.ToString(),
                     DateOfBirth = p.DateOfBirth.ToString("yyyy/MM/dd"),
                     PetType = p.PetType.Name,
                     Breed = p.Breed,
                     Color = p.Color,
                     Shelter = p.Shelter.Name,
                     IsAdopted = p.IsAdopted,
                 })
             .FirstOrDefaultAsync();
        }
    }
}
