using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Services.Data.Models.AdoptPet;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Adopt;
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
        private readonly ILogger logger;

        public AdoptController(IAdoptService service,
            IPetTypeService petTypeService,
             ILogger<AdoptController> logger)
        {
            this.service = service;
            this.petTypeService = petTypeService;
            this.logger = logger;
        }

        public async Task<IActionResult> Adopt([FromQuery] AllPetsForAdoptionQueryModel queryModel)
        {
            AllPetsForAdoptionFilteredAndPagesServiceModel serviceModel =
                await this.service.AllAsync(queryModel);

            queryModel.Pets = serviceModel.Pets;
            queryModel.TotalPets = serviceModel.TotalPetsCount;
            queryModel.PetsTypes = await this.petTypeService.AllPetsTypesNamesAsync();
            
            logger.LogInformation("Successfully visualized pets for adoption");

            return View(queryModel);
        }

        public async Task<IActionResult> AdoptDog()
        {
            var model = await this.service.GetDogsForAdoptionAsync();
            logger.LogInformation("Successfully visualized dogs for adoption");
            return View(model);
        }

        public async Task<IActionResult> AdoptCat()
        {
            var model = await this.service.GetCatsForAdoptionAsync();
            logger.LogInformation("Successfully visualized cats for adoption");
            return View(model);
        }

        public async Task<IActionResult> AdoptBird()
        {
            var model = await this.service.GetBirdsForAdoptionAsync();
            logger.LogInformation("Successfully visualized birds for adoption");
            return View(model);
        }

        public async Task<IActionResult> AdoptRabbit()
        {
            var model = await this.service.GetRabbitsForAdoptionAsync();
            logger.LogInformation("Successfully visualized rabbits for adoption");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Adoption(int id)
        {
            var model = await service.GetPetForAdoptionByIdAsync(id);

            logger.LogInformation("Successfully visualized adoption view");

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
                logger.LogWarning("You cannot adopt this pet!");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to adopt a pet!");
                TempData[ErrorMessage] = "You cannot adopt this pet!";
                logger.LogWarning("You cannot adopt this pet!");
                return BadRequest();
            }

            var adopter = this.User.GetId();

            if (adopter == null)
            {
                TempData[ErrorMessage] = "You cannot adopt this pet!";
                logger.LogWarning("You cannot adopt this pet!");
                return Unauthorized(); 
            }

            try
            {
                await this.service.UpdatePetForAdoptionAsync(petForAdoption, adopter);
                await this.service.AddAdoption(adopter, petForAdoption);
                TempData[SuccessMessage] = "You have successfully adopted a pet!";
                logger.LogInformation("You have successfully adopted a pet!");
                return RedirectToAction("Index", "Home"); 
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
