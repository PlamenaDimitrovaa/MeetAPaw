
using MeetAPaw.Web.ViewModels.Pet;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetViewModel>> GetAllPetsAsync();

        Task<PetProfileViewModel> GetProfileAsync(int id);

        Task AddPetAsync(AddPetViewModel model, string ownerId);

        Task<PetViewModel?> GetPetByIdAsync(int id);

        Task<EditPetViewModel> GetPetForEditByIdAsync(int id);

        Task EditPetByIdAsync(int id, EditPetViewModel model);

        Task<bool> PetExistsByIdAsync(int id);
    }
}
