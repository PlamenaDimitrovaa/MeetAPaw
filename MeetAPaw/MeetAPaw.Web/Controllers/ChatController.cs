using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class ChatController : BaseController
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
