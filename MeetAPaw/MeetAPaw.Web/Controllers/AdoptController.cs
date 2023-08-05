using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Services.Data.Models.AdoptPet;
using MeetAPaw.Services.Data.Models.Pet;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MeetAPaw.Common.NotificationMessagesConstants;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class AdoptController : BaseController
    {
        private readonly IAdoptService service;
        private readonly IPetTypeService petTypeService;

        public AdoptController(IAdoptService service,
            IPetTypeService petTypeService)
        {
            this.service = service;
            this.petTypeService = petTypeService;
        }

        public async Task<IActionResult> Adopt([FromQuery] AllPetsForAdoptionQueryModel queryModel)
        {
            AllPetsForAdoptionFilteredAndPagesServiceModel serviceModel =
                await this.service.AllAsync(queryModel);

            queryModel.Pets = serviceModel.Pets;
            queryModel.TotalPets = serviceModel.TotalPetsCount;
            queryModel.PetsTypes = await this.petTypeService.AllPetsTypesNamesAsync();

            return View(queryModel);
        }

        //public async Task<IActionResult> Adopt()
        //{
        //    try
        //    {
        //        var model = await this.service.GetPetsForAdoptionAsync();
        //        return View(model);

        //    }
        //    catch (Exception)
        //    {
        //        TempData[ErrorMessage] = "You have go log in to adopt a pet!";
        //        throw;
        //    }
        //}

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
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Adoption(int petId, int adopterId)
        {
            var petForAdoption = await this.service.GetPetForAdoptionAsync(petId);

            if (petForAdoption == null)
            {
                TempData[ErrorMessage] = "You cannot adopt this pet!";
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to adopt a pet!");
                TempData[ErrorMessage] = "You cannot adopt this pet!";
                return BadRequest();
            }

            var adopter = this.User.GetId();

            if (adopter == null)
            {
                TempData[ErrorMessage] = "You cannot adopt this pet!";
                return Unauthorized(); 
            }

            try
            {
                await this.service.UpdatePetForAdoptionAsync(petForAdoption, adopter);
                await this.service.AddAdoption(adopter, petForAdoption);
                TempData[SuccessMessage] = "You have successfully adopted a pet!";
                return RedirectToAction("Index", "Home"); 
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
