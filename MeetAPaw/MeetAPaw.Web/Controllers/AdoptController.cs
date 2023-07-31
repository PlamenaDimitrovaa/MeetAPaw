using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Adopt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MeetAPaw.Common.NotificationMessagesConstants;

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
            try
            {
                var model = await this.service.GetPetsForAdoptionAsync();
                return View(model);

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "You have go log in to adopt a pet!";
                throw;
            }
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

        [HttpGet]
        public async Task<IActionResult> Adoption(int id)
        {
            var model = await service.GetPetForAdoptionByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "You cannot adopt this pet!";
                return BadRequest();
            }

            TempData[SuccessMessage] = "You have successfully adopted a pet!";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Adoption(int petId, int adopterId)
        {
            var petForAdoption = await this.service.GetPetForAdoptionAsync(petId);

            if (petForAdoption == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to adopt a pet!");
                return BadRequest();
            }

            var adopter = this.User.GetId();

            if (adopter == null)
            {
                return Unauthorized(); 
            }

            try
            {
                await this.service.UpdatePetForAdoptionAsync(petForAdoption, adopter);
                await this.service.AddAdoption(adopter, petForAdoption);
                return RedirectToAction("Index", "Home"); 
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
