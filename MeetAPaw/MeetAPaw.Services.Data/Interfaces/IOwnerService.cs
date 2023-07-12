
namespace MeetAPaw.Services.Data.Interfaces
{
    public interface IOwnerService
    {
        Task<bool> OwnerExistsByUserIdAsync(string userId);

        Task<bool> OwnerExistsByPhoneNumberAsync(string phoneNumber);

        //Task<bool> HasAdoptionsByUserIdAsync(string userId);

      //  Task Create(string userId, BecomeOwnerViewModel model);

        Task<string?> GetOwnerIdByUserIdAsync(string userId);
    }
}
