
namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> UserFullName(string email);
    }
}
