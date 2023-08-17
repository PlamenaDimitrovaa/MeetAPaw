using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Tests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [SetUp]
        public void SetUp()
        {
            this.userService = new UserService(this.data);
        }

        [Test]
        public async Task GetAllUsersAsyncMethodShouldReturnUsersCorrectly()
        {
            await this.data.Users.AddRangeAsync(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.Parse("E23A4F9D-7C12-4E6B-BC86-3D79E8A2F354"),
                    FirstName = "testFirstName1",
                    LastName = "testLastName1"
                },
                 new ApplicationUser
                {
                    Id = Guid.Parse("F6DAB1E2-9F8C-4A02-BC97-6E3518DA724C"),
                    FirstName = "testFirstName2",
                    LastName = "testLastName2"
                },
            });

            await this.data.SaveChangesAsync();

            var users = await this.userService.AllAsync();

            Assert.That(users.Count(), Is.EqualTo(3));
        }

        [Test]
        [TestCase("testUser@gmail.com")]
        public async Task UserFullNameShouldReturnTrueResult(string email)
        {
            var user = await this.data
                .Users.FirstOrDefaultAsync(u => u.Email == email);

            var result = user.FirstName + " " + user.LastName;

            Assert.That(result, Is.EqualTo("TestFirstName TestLastName"));
        }

        [Test]
        [TestCase("gmail.com")]
        public async Task UserFullNameShouldReturnFalseResult(string email)
        {
            var user = await this.data
                .Users.FirstOrDefaultAsync(u => u.Email == email);

            Assert.That(user, Is.EqualTo(null));
        }
    }
}
