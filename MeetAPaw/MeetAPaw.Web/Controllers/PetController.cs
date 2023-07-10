using MeetAPaw.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService service;
        public PetController(IPetService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await this.service.GetAllPetsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var model = await service.GetProfileAsync(id);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
