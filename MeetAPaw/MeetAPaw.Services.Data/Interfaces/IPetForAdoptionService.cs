
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.PetForAdoption;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IPetForAdoptionService
    {
        Task<int> AddPetForAdoptionAsync(AddPetForAdoptionViewModel model);

        Task<PetForAdoptionProfileViewModel?> GetProfileToPetForAdoptionAsync(int id);

        Task<EditPetForAdoptionViewModel> GetPetForAdoptionForEditByIdAsync(int id);


        Task EditPetForAdoptionByIdAsync(int id, EditPetForAdoptionViewModel model);

        Task<bool> PetForAdoptionExistsByIdAsync(int id);

        Task<PetForAdoptionPreDeleteDetailsViewModel> GetPetForAdoptionForDeleteByIdAsync(int id);

        Task DeletePetForAdoptionByIdAsync(int id);

        Task<PetForAdoptionViewModel> GetPetForAdoptionByIdAsync(int id);
    }
}
