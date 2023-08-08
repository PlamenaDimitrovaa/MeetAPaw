using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Services.Data.Models.Pet;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MeetAPaw.Common.NotificationMessagesConstants;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class PetController : BaseController
    {
        private readonly IPetService service;
        private readonly IPetTypeService petTypeService;
        private readonly ILogger logger;

        public PetController(
            IPetService service,
            IPetTypeService petTypeService,
            ILogger<PetController> logger)
        {
            this.service = service;
            this.petTypeService = petTypeService;
            this.logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllPetsQueryModel queryModel)
        {
            AllPetsFilteredAndPagesServiceModel serviceModel = 
                await this.service.AllAsync(queryModel);

            queryModel.Pets = serviceModel.Pets;
            queryModel.TotalPets = serviceModel.TotalPetsCount;
            queryModel.PetsTypes = await this.petTypeService.AllPetsTypesNamesAsync();
            logger.LogInformation("Successfully visualized pets");
            return View(queryModel);
        }

        public async Task<IActionResult> Profile(int id)
        {
            var model = await service.GetProfileAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            logger.LogInformation("Successfully visualized profile of a pet.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/About")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddPetViewModel viewModel = new AddPetViewModel()
            {
                PetsTypes = await this.petTypeService.AllPetTypesAsync()
            };

            viewModel.OwnerId = GetUserId();
            logger.LogInformation("Successfully visualized add form.");
            return View(viewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPetViewModel model)
        {
            bool petTypeExists = await this.petTypeService.ExistsByIdAsync(model.PetTypeId);

            if (!petTypeExists)
            {
                ModelState.AddModelError(nameof(model.PetTypeId), "Selected pet type does not exist!");
            }

            if (this.User.GetId() != model.OwnerId && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be registered in order to add pets!";
                return this.RedirectToAction("All", "Pet");
            }

            string date = WebUtility.HtmlEncode(model.DateOfBirth.ToString());
            
            DateTime dateOfBirth = DateTime.Parse(date);

            if (dateOfBirth >= DateTime.UtcNow)
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), "Selected date of birth is not valid!");
            }

            if (!ModelState.IsValid)
            {
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                TempData[ErrorMessage] = "You cannot add a new pet!";
                return View(model);
            }

            try
            {
                await this.service.AddPetAsync(model, this.User.GetId()!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new pet! Please try again later or contact administrator.");
                logger.LogWarning("Unexpected error occurred.");
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                return this.View(model);
            }

            logger.LogInformation("Successfully added pet.");
            TempData[SuccessMessage] = "You have added a new pet successfully!";
            return RedirectToAction("All", "Pet");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                EditPetViewModel viewModel = await this.service.GetPetForEditByIdAsync(id);

                viewModel.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                viewModel.OwnerId = GetUserId();
                logger.LogInformation("Successfully visualized edit pet form.");
                return View(viewModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPetViewModel model)
        {
            bool petExists = await this.service
                .PetExistsByIdAsync(id);

            if (!petExists)
            {
                TempData[ErrorMessage] = "This pet does not exists!";
                logger.LogWarning("This pet does not exists!");
                return this.RedirectToAction("All", "Pet");
            }

            if (this.User.GetId() != model.OwnerId && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an owner in order to make changes!";
                return this.RedirectToAction("All", "Pet");
            }

            string date = WebUtility.HtmlEncode(model.DateOfBirth.ToString());
           
            DateTime dateOfBirth = DateTime.Parse(date);

            if (dateOfBirth >= DateTime.UtcNow)
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), "Selected date of birth is not valid!");
            }

            if (!this.ModelState.IsValid)
            {
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                TempData[ErrorMessage] = "You cannot edit this pet!";
                return this.View(model);
            }

            try
            {
                await this.service.EditPetByIdAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the pet. Please try again later or contact administrator!");
                logger.LogWarning("Unexpected error occurred");
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                return this.View(model);
            }

            logger.LogInformation("Successfully added pet!");
            TempData[SuccessMessage] = "You have edited the pet successfully!";
            return this.RedirectToAction("Profile", "Pet", new { id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool houseExists = await this.service
                .PetExistsByIdAsync(id);

            if (!houseExists)
            {
                logger.LogWarning("This pet does not exists.");
                return this.RedirectToAction("All", "Pet");
            }

            try
            {
                PetPreDeleteDetailsViewModel viewModel =
                    await this.service.GetPetForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PetPreDeleteDetailsViewModel model)
        {
            bool petExists = await this.service
                .PetExistsByIdAsync(id);

            if (!petExists)
            {
                logger.LogWarning("This pet does not exists!");
                TempData[ErrorMessage] = "You cannot delete this pet!";
                return this.RedirectToAction("All", "Pet");
            }

            try
            {
                await this.service.DeletePetByIdAsync(id);
                logger.LogInformation("You have deleted the pet successfully!");
                TempData[SuccessMessage] = "You have deleted the pet successfully!";
                return this.RedirectToAction("All", "Pet");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
