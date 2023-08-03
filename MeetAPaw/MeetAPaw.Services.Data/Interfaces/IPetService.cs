
using MeetAPaw.Services.Data.Models.Pet;
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

        Task<PetPreDeleteDetailsViewModel> GetPetForDeleteByIdAsync(int id);

        Task DeletePetByIdAsync(int id);

        Task<AllPetsFilteredAndPagesServiceModel> AllAsync(AllPetsQueryModel queryModel);
    }
}
