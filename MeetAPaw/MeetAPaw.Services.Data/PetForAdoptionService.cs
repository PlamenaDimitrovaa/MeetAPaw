using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Data.Models.Enums;
using MeetAPaw.Services.Data.Interfaces;
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
        public async Task<int> AddPetForAdoptionAsync(AddPetForAdoptionViewModel model)
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

            return pet.Id;
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
                     DateOfBirth = p.DateOfBirth.ToString("dddd, dd MMMM yyyy HH:mm"),
                     PetType = p.PetType.Name,
                     Breed = p.Breed,
                     Color = p.Color,
                     Shelter = p.Shelter.Name,
                     IsAdopted = p.IsAdopted,
                     User = p.User.UserName
                 })
             .FirstOrDefaultAsync();
        }
        public async Task<EditPetForAdoptionViewModel> GetPetForAdoptionForEditByIdAsync(int id)
        {
            PetForAdoption pet = await this.context
                .PetsForAdoption
                .Include(p => p.PetType)
                .FirstAsync(p => p.Id == id);

            return new EditPetForAdoptionViewModel()
            {
                Id = pet.Id,
                Name = pet.Name,
                Description = pet.Description,
                ImageUrl = pet.ImageUrl,
                Gender = pet.Gender.ToString(),
                Breed = pet.Breed,
                Color = pet.Color,
                DateOfBirth = pet.DateOfBirth.ToString("dddd, dd MMMM yyyy HH:mm"),
                UserId = pet.UserId.ToString(),
                PetTypeId = pet.PetTypeId,
                IsAdopted = pet.IsAdopted,
                ShelterId = pet.ShelterId,
            };
        }
        public async Task EditPetForAdoptionByIdAsync(int id, EditPetForAdoptionViewModel model)
        {
            PetForAdoption pet = await this.context
                .PetsForAdoption
                .FirstAsync(h => h.Id == id);

            pet.Name = model.Name;
            pet.Description = model.Description;
            pet.ImageUrl = model.ImageUrl;
            pet.Breed = model.Breed;
            pet.Color = model.Color;
            pet.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            pet.UserId = Guid.Parse(model.UserId);
            pet.Gender = Enum.Parse<PetGender>(model.Gender);
            pet.PetTypeId = model.PetTypeId;
            pet.IsAdopted = model.IsAdopted;
            pet.ShelterId = model.ShelterId;

            await this.context.SaveChangesAsync();
        }
        public async Task<bool> PetForAdoptionExistsByIdAsync(int id)
        {
            bool result = await this.context
                .PetsForAdoption.AnyAsync(h => h.Id == id);

            return result;
        }
        public async Task<PetForAdoptionPreDeleteDetailsViewModel> GetPetForAdoptionForDeleteByIdAsync(int id)
        {
            PetForAdoption pet = await this.context
                .PetsForAdoption
                .FirstAsync(h => h.Id == id);

            return new PetForAdoptionPreDeleteDetailsViewModel
            {
                Name = pet.Name,
                ImageUrl = pet.ImageUrl
            };
        }
        public async Task<PetForAdoptionViewModel?> GetPetForAdoptionByIdAsync(int id)
        {
            return await this.context.PetsForAdoption
                .Where(h => h.Id == id)
                .Select(h => new PetForAdoptionViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Breed = h.Breed,
                    PetTypeId = h.PetTypeId,
                    Address = h.Address,
                    ShelterId = h.ShelterId,
                    DateOfBirth = h.DateOfBirth.ToString()
                }).FirstOrDefaultAsync();
        }
        public async Task DeletePetForAdoptionByIdAsync(int id)
        {
            PetForAdoption petToDelete = await this.context
                .PetsForAdoption
                .FirstAsync(h => h.Id == id);

            this.context.PetsForAdoption.Remove(petToDelete);
            await this.context.SaveChangesAsync();
        }
    }
}
