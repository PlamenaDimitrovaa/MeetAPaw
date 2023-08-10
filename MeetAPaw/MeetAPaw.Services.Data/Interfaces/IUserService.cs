
using MeetAPaw.Web.ViewModels.User;

namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> UserFullName(string email);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
