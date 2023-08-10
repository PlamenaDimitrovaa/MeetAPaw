using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.AllAsync();
            
            return View(users);
        }
    }
}
