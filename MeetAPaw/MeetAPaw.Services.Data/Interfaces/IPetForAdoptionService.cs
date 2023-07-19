
using MeetAPaw.Web.ViewModels.PetForAdoption;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IPetForAdoptionService
    {
        public Task AddPetForAdoptionAsync(AddPetForAdoptionViewModel model);
    }
}
