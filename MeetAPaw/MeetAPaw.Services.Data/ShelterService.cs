
using MeetAPaw.Data;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.PetForAdoption;
using MeetAPaw.Web.ViewModels.PetType;
using MeetAPaw.Web.ViewModels.Shelter;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class ShelterService : IShelterService
    {
        private readonly MeetAPawDbContext context;

        public ShelterService(MeetAPawDbContext context)
        {
            this.context = context;   
        }

        public async Task<IEnumerable<ShelterViewModel>> AllSheltersAsync()
        {
            IEnumerable<ShelterViewModel> allShelters =
                 await this.context.Shelters
                 .AsNoTracking()
                 .Select(p => new ShelterViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Address = p.Address,
                 })
                 .ToArrayAsync();

            return allShelters;
        }

        public async Task<ShelterProfileViewModel> GetProfileAsync(int id)
        {
            return await context.Shelters
               .Where(p => p.Id == id)
               .Select(p => new ShelterProfileViewModel()
               {
                   Id = p.Id,
                   Name = p.Name,
                   Address = p.Address,
                   PetsForAdoption = context.PetsForAdoption
                                        .Where(pd => pd.ShelterId == p.Id)
                                        .Select(pd => new PetForAdoptionViewModel 
                                        { 
                                            Id = pd.Id,
                                            Name = pd.Name,
                                            Address = pd.Address,
                                            Breed = pd.Breed,
                                            ShelterId = pd.ShelterId,
                                            DateOfBirth = pd.DateOfBirth.ToString("yyyy-MM-dd"),
                                            PetTypeId = pd.PetTypeId,
                                            PetType = pd.PetType.Name
                                        }).ToList(),
                   Adoptions = context.Adoptions
                                       .Where(a => a.ShelterId == p.Id)
                                       .Select(a => new AdoptionViewModel 
                                       {
                                           Id = a.Id,
                                           Adopter = a.Adopter.FirstName,
                                           AdopterId = a.AdopterId.ToString(),
                                           PetForAdoptionId = a.PetForAdoptionId,
                                           Pet = a.PetForAdoption.Name,
                                           Date = a.Date.ToString("yyyy-MM-dd"),
                                           MoreInformation = a.MoreInformation,
                                           ShelterId = a.ShelterId
                                       }).ToList()
               })
           .FirstOrDefaultAsync();
        }

        public async Task<bool> ShelterExistsByIdAsync(int id)
        {
            bool result = await this.context.Shelters
                .AnyAsync(p => p.Id == id);

            return result;
        }
    }
}
