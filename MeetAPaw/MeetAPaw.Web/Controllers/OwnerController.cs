using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    public class OwnerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
