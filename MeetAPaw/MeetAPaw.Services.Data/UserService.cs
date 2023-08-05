
using MeetAPaw.Data;
using MeetAPaw.Services.Data.Interfaces;

namespace MeetAPaw.Services.Data
{
    public class UserService : IUserService
    {
        private readonly MeetAPawDbContext context;

        public UserService(MeetAPawDbContext _context)
        {
            this.context = _context;
        }

        public string UserFullName(string userId)
        {
            var user = this.context.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
