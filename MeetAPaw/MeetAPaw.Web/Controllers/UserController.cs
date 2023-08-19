using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;

        public UserController(
            IUserService userService,
            ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId = null)
        {
            try
            {
                ProfileViewModel user;

                if (userId == null)
                {
                    user = await this.userService.GetProfileInfoAsync(User.GetId());
                }
                else
                {
                    user = await this.userService.GetProfileInfoAsync(userId);
                }

                if (user == null)
                {
                    return RedirectToAction(nameof(Details));
                }

                return View(user);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"{ex.GetType()}: {ex.Message}, \n {ex.StackTrace}");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OwnedPets()
        {
            var userId = User.GetId();
            var pets = await this.userService.GetUserPetsAsync(userId);
            return View(pets);
        }

        [HttpGet]
        public async Task<IActionResult> AdoptedPets()
        {
            var userId = User.GetId();
            var pets = await this.userService.GetUserAdoptedPetsAsync(userId);
            return View(pets);
        }
    }
}
