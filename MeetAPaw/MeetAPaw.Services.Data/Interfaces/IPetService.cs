
using MeetAPaw.Web.ViewModels.Pet;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetViewModel>> GetAllPetsAsync();

        Task<PetProfileViewModel> GetProfileAsync(int id);

        Task<AddPetViewModel> GetNewAddPetAsync();

        Task AddPetAsync(AddPetViewModel model);

        Task<PetViewModel?> GetPetByIdAsync(int id);

    }
}
