using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MeetAPaw.Common.GeneralApplicationConstants;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName});
            }

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Pet");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return View();
        }
    }
}