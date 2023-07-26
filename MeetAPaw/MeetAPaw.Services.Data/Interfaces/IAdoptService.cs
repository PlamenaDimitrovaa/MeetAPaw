
using MeetAPaw.Data.Models;
using MeetAPaw.Web.ViewModels.Adopt;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IAdoptService
    {
        Task<IEnumerable<AdoptPetViewModel>> GetPetsForAdoptionAsync();
        Task<IEnumerable<AdoptPetViewModel>> GetDogsForAdoptionAsync();
        Task<IEnumerable<AdoptPetViewModel>> GetCatsForAdoptionAsync();
        Task<IEnumerable<AdoptPetViewModel>> GetBirdsForAdoptionAsync();
        Task<IEnumerable<AdoptPetViewModel>> GetRabbitsForAdoptionAsync();
        Task<PetForAdoption?> GetPetForAdoptionAsync(int petId);

        Task UpdatePetForAdoptionAsync(PetForAdoption petForAdoption, string adopterId);

        Task AddAdoption(string adopterId, PetForAdoption petForAdoption);

        Task<AdoptPetViewModel?> GetPetForAdoptionByIdAsync(int id);
    }
}
