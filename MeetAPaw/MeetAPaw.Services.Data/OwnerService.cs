
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Data
{
    public class OwnerService : IOwnerService
    {
        private readonly MeetAPawDbContext context;

        public OwnerService(MeetAPawDbContext context)
        {
            this.context = context;
        }

        public async Task<string?> GetOwnerIdByUserIdAsync(string userId)
        {
            Owner? owner = await this.context
                .Owners
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (owner == null)
            {
                return null;
            }

            return owner.Id.ToString();
        }

        //public async Task<bool> HasAdoptionsByUserIdAsync(string userId)
        //{
        //    ApplicationUser? user = await this.context
        //        .Users
        //        .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

        //    if (user == null)
        //    {
        //        return false;
        //    }

        //    return user.AdoptedPets.Any();
        //}

        public async Task<bool> OwnerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.context.Owners
               .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> OwnerExistsByUserIdAsync(string userId)
        {
            bool result = await this.context.Owners
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }
    }
}
