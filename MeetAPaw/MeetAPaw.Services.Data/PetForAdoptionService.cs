
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Data.Models.Enums;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.PetForAdoption;

namespace MeetAPaw.Services.Data
{
    public class PetForAdoptionService : IPetForAdoptionService
    {
        private readonly MeetAPawDbContext context;

        public PetForAdoptionService(MeetAPawDbContext context)
        {
            this.context = context;
        }

        public async Task AddPetAsync(AddPetForAdoptionViewModel model)
        {
            PetForAdoption pet = new PetForAdoption()
            {
                Id = model.Id,
                Name = model.Name,
                Breed = model.Breed,
                Address = model.Address,
                Description = model.Description,
                Color = model.Color,
                ImageUrl = model.ImageUrl,
                Gender = Enum.Parse<PetGender>(model.Gender),
                DateOfBirth = DateTime.Parse(model.DateOfBirth),
                PetTypeId = model.PetTypeId,
            };

            await this.context.PetsForAdoption.AddAsync(pet);
            await this.context.SaveChangesAsync();
        }
    }
}
