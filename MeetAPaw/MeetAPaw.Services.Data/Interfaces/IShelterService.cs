
using MeetAPaw.Web.ViewModels.PetType;
using MeetAPaw.Web.ViewModels.Shelter;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IShelterService
    {
        Task<IEnumerable<ShelterViewModel>> AllSheltersAsync();

        Task<bool> ShelterExistsByIdAsync(int id);
    }
}
