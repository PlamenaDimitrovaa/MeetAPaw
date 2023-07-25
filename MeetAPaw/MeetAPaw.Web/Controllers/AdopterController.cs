using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    public class AdopterController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
