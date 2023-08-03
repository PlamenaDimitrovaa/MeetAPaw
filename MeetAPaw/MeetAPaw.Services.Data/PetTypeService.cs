
using MeetAPaw.Data;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.PetType;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class PetTypeService : IPetTypeService
    {
        private readonly MeetAPawDbContext dbContext;

        public PetTypeService(MeetAPawDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllPetsTypesNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .PetsTypes
                .Select(pt => pt.Name)
                .ToListAsync();

            return allNames;
        }

        public async Task<IEnumerable<PetTypeViewModel>> AllPetTypesAsync()
        {
            IEnumerable<PetTypeViewModel> allPetTypes =
                  await this.dbContext.PetsTypes
                  .AsNoTracking()
                  .Select(p => new PetTypeViewModel()
                  {
                      Id = p.Id,
                      Name = p.Name,
                  })
                  .ToArrayAsync();

            return allPetTypes;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext.PetsTypes
                .AnyAsync(p => p.Id == id);

            return result;
        }
    }
}
