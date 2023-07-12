
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Data.Models.Enums;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class PetService : IPetService
    {
        private readonly MeetAPawDbContext context;

        public PetService(MeetAPawDbContext context)
        {
            this.context = context;
        }

        public async Task AddPetAsync(AddPetViewModel model, string ownerId)
        {
            Pet pet = new Pet()
            {
                Name = model.Name,
                Breed = model.Breed,
                Address = model.Address,
                Description = model.Description,
                Color = model.Color,
                ImageUrl = model.ImageUrl,
                Gender = Enum.Parse<PetGender>(model.Gender),
                DateOfBirth = DateTime.Parse(model.DateOfBirth),
                PetTypeId = model.PetTypeId,
                OwnerId = Guid.Parse(ownerId)
            };

            await this.context.Pets.AddAsync(pet);
            await this.context.SaveChangesAsync();   
        }

        public async Task<IEnumerable<PetViewModel>> GetAllPetsAsync()
        {
            return await context.Pets.Select(p => new PetViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Gender = p.Gender.ToString(),
                DateOfBirth = p.DateOfBirth.ToString(),
                PetType = p.PetType.Name,
                Breed = p.Breed
            })
                .ToListAsync();
        }

        //public async Task<AddPetViewModel> GetNewAddPetAsync()
        //{
        //    var petTypes = await context.PetsTypes
        //        .Select(pt => new PetTypeViewModel()
        //        {
        //            Id = pt.Id,
        //            Name = pt.Name,
        //        })
        //        .ToListAsync();

        //    var model = new AddPetViewModel()
        //    {
        //        PetsTypes = petTypes
        //    };

        //    return model;
        //}

        public async Task<PetViewModel?> GetPetByIdAsync(int id)
        {
            return await this.context.Pets
                .Where(p => p.Id == id)
                .Select(p => new PetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString("yyyy/MM/dd"),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PetProfileViewModel?> GetProfileAsync(int id)
        {
            return await context.Pets
                .Where(p => p.Id == id)
                .Select(p => new PetProfileViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                Gender = p.Gender.ToString(),
                DateOfBirth= p.DateOfBirth.ToString("yyyy/MM/dd"),
                PetType= p.PetType.Name,
                Breed = p.Breed,
                Owner = p.Owner.User.UserName,
                Color = p.Color
            })
            .FirstOrDefaultAsync();
        }
    }
}
