using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.User;
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
        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            var users = await this.context
                .Users
                .Select(u => new UserViewModel 
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();

            return users;
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


        public async Task EditUserAsync(EditUserViewModel model)
        {
            var user = await this.context
                .Users
                .Where(u => u.Id.ToString() == model.Id)
                .FirstOrDefaultAsync();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await this.context.SaveChangesAsync();
        }

        public async Task<int> GetCountOfUsersAsync()
           => await this.context
                        .Users
                        .CountAsync();

        public async Task<ProfileViewModel> GetProfileInfoAsync(string userId)
        {
            var user = await this.context
                .Users
                .Where(u => u.Id.ToString() == userId)
                .Select(u => new ProfileViewModel
                {
                    Id = u.Id.ToString(),
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                })
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<PetViewModel>> GetUserPetsAsync(string userId)
        {
            return await context.Pets
                .Where(p => p.OwnerId.ToString() == userId)
                .Select(p => new PetViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Gender = p.Gender.ToString(),
                DateOfBirth = p.DateOfBirth.ToString("dddd, dd MMMM yyyy HH:mm"),
                PetType = p.PetType.Name,
                Breed = p.Breed
            })
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptPetViewModel>> GetUserAdoptedPetsAsync(string userId)
        {
            return await context.PetsForAdoption
                .Where(p => p.IsAdopted == true && p.AdopterId.ToString() == userId)
                .Select(p => new AdoptPetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    DateOfBirth = p.DateOfBirth.ToString(),
                    PetType = p.PetType.Name,
                    Breed = p.Breed
                })
                .ToListAsync();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await this.context
                .Users
                .FindAsync(userId);
        }
    }
}
