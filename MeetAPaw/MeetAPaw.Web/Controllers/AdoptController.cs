using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class AdoptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
