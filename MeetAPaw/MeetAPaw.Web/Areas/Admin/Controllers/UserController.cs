using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;

        public UserController(
             IUserService _userService,
             ILogger<UserController> logger)
        {
            this.userService = _userService;
            this.logger = logger;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.AllAsync();
            
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId = null)
        {
            try
            {
                ProfileViewModel user;
                user = await this.userService.GetProfileInfoAsync(userId);

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
    }
}
