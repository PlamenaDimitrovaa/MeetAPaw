
namespace MeetAPaw.Web.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        
        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
