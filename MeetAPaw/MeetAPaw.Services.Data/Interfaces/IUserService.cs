using MeetAPaw.Data.Models;
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.User;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> UserFullName(string email);
        Task<IEnumerable<UserViewModel>> AllAsync();
        Task<ProfileViewModel> GetProfileInfoAsync(string userId);
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<IEnumerable<PetViewModel>> GetUserPetsAsync(string userId);
        Task<IEnumerable<AdoptPetViewModel>> GetUserAdoptedPetsAsync(string userId);
        Task EditUserAsync(EditUserViewModel model);
        Task<EditUserViewModel> GetUserForEditAsync(string userId);
    }
}
