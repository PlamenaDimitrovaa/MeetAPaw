using MeetAPaw.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class AdoptController : BaseController
    {
        private readonly IAdoptService service;

        public AdoptController(IAdoptService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Adopt()
        {
            var model = await this.service.GetPetsForAdoptionAsync();
            return View(model);
        }

        public async Task<IActionResult> AdoptDog()
        {
            var model = await this.service.GetDogsForAdoptionAsync();
            return View(model);
        }

        public async Task<IActionResult> AdoptCat()
        {
            var model = await this.service.GetCatsForAdoptionAsync();
            return View(model);
        }

        public async Task<IActionResult> AdoptBird()
        {
            var model = await this.service.GetBirdsForAdoptionAsync();
            return View(model);
        }

        public async Task<IActionResult> AdoptRabbit()
        {
            var model = await this.service.GetRabbitsForAdoptionAsync();
            return View(model);
        }
    }
}
