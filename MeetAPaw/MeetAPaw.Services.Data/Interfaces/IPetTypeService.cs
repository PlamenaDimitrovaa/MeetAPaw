using MeetAPaw.Web.ViewModels.PetType;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IPetTypeService
    {
        Task<IEnumerable<PetTypeViewModel>> AllPetTypesAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<string>> AllPetsTypesNamesAsync();
    }
}
