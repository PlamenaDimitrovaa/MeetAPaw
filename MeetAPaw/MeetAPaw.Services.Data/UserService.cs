
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class UserService : IUserService
    {
        private readonly MeetAPawDbContext context;

        public UserService(MeetAPawDbContext _context)
        {
            this.context = _context;
        }

        public async Task<string> UserFullName(string email)
        {
            ApplicationUser? user = await this.context
                .Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
