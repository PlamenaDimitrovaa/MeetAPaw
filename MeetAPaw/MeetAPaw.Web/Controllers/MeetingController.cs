using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
