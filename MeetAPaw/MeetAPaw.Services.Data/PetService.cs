
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Data.Models.Enums;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Services.Data.Models.Pet;
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

        public async Task<EditPetViewModel> GetPetForEditByIdAsync(int id)
        {
            Pet pet = await this.context
                .Pets
                .Include(p => p.PetType)
                .FirstAsync(p => p.Id == id);

            return new EditPetViewModel()
            {
                Id = pet.Id,
                Name = pet.Name,
                Address = pet.Address,
                Description = pet.Description,
                ImageUrl = pet.ImageUrl,
                Gender = pet.Gender.ToString(),
                Breed = pet.Breed,
                Color = pet.Color,
                DateOfBirth = pet.DateOfBirth.ToString(),
                OwnerId = pet.OwnerId.ToString(),
                PetTypeId = pet.PetTypeId
            };
        }

        public async Task EditPetByIdAsync(int id, EditPetViewModel model)
        {
            Pet pet = await this.context
                .Pets
                .FirstAsync(h => h.Id == id);

            pet.Name = model.Name;
            pet.Address = model.Address;
            pet.Description = model.Description;
            pet.ImageUrl = model.ImageUrl;
            pet.Breed = model.Breed;
            pet.Color = model.Color;
            pet.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            pet.OwnerId = Guid.Parse(model.OwnerId);
            pet.Gender = Enum.Parse<PetGender>(model.Gender);
            pet.PetTypeId = model.PetTypeId;

            await this.context.SaveChangesAsync();
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
                Owner = p.Owner.UserName,
                Color = p.Color
            })
            .FirstOrDefaultAsync();
        }

        public async Task<bool> PetExistsByIdAsync(int id)
        {
            bool result = await this.context
                .Pets
                .AnyAsync(p => p.Id == id);

            return result;
        }

        public async Task<PetPreDeleteDetailsViewModel> GetPetForDeleteByIdAsync(int id)
        {
            Pet pet = await this.context
                .Pets
                .FirstAsync(h => h.Id == id);

            return new PetPreDeleteDetailsViewModel
            {
                Name = pet.Name,
                Address = pet.Address,
                ImageUrl = pet.ImageUrl
            };
        }

        public async Task DeletePetByIdAsync(int id)
        {
            Pet petToDelete = await this.context
                .Pets
                .FirstAsync(h => h.Id == id);

            this.context.Pets.Remove(petToDelete);
            await this.context.SaveChangesAsync();
        }

        public async Task<AllPetsFilteredAndPagesServiceModel> AllAsync(AllPetsQueryModel queryModel)
        {
            IQueryable<Pet> petsQuery = this.context
                .Pets
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
                                EF.Functions.Like(p.Address, wildCard) ||
                                EF.Functions.Like(p.Breed, wildCard) ||
                                EF.Functions.Like(p.PetType.Name, wildCard));
            }

            var allPets = await petsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.PetsPerPage)
                .Take(queryModel.PetsPerPage)
                .Select(p => new PetViewModel
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

            int totalPets = petsQuery.Count();

            return new AllPetsFilteredAndPagesServiceModel()
            {
                TotalPetsCount = totalPets,
                Pets = allPets
            };
        }
    }
}
