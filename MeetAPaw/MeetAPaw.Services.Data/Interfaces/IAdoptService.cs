
using MeetAPaw.Web.ViewModels.Adopt;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IAdoptService
    {
        public Task<IEnumerable<AdoptPetViewModel>> GetPetsForAdoptionAsync();
        public Task<IEnumerable<AdoptPetViewModel>> GetDogsForAdoptionAsync();
        public Task<IEnumerable<AdoptPetViewModel>> GetCatsForAdoptionAsync();
        public Task<IEnumerable<AdoptPetViewModel>> GetBirdsForAdoptionAsync();
        public Task<IEnumerable<AdoptPetViewModel>> GetRabbitsForAdoptionAsync();

    }
}
