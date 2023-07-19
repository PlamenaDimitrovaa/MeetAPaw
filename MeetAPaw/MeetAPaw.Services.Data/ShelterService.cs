
using MeetAPaw.Data;
using MeetAPaw.Services.Data.Interfaces;
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

        public async Task<bool> ShelterExistsByIdAsync(int id)
        {
            bool result = await this.context.Shelters
                .AnyAsync(p => p.Id == id);

            return result;
        }
    }
}
