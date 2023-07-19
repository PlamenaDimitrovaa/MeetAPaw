using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Pet;
using MeetAPaw.Web.ViewModels.PetForAdoption;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    public class PetForAdoptionController : BaseController
    {
        private readonly IPetForAdoptionService service;
        private readonly IPetTypeService petTypeService;
        private readonly IShelterService shelterService;

        public PetForAdoptionController(
            IPetForAdoptionService service,
            IPetTypeService petService,
            IShelterService shelterService)
        {
            this.service = service;
            this.petTypeService = petService;
            this.shelterService = shelterService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddPetForAdoptionViewModel viewModel = new AddPetForAdoptionViewModel()
            {
                Shelters = await this.shelterService.AllSheltersAsync(),
                PetsTypes = await this.petTypeService.AllPetTypesAsync()
            };


            viewModel.UserId = GetUserId();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPetForAdoptionViewModel model)
        {
            bool petTypeExists = await this.petTypeService.ExistsByIdAsync(model.PetTypeId);

            if (!petTypeExists)
            {
                ModelState.AddModelError(nameof(model.PetTypeId), "Selected pet type does not exist!");
            }

            bool sheltersExists = await this.shelterService.ShelterExistsByIdAsync(model.ShelterId);

            if (!sheltersExists)
            {
                ModelState.AddModelError(nameof(model.ShelterId), "Selected shelter does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Shelters = await this.shelterService.AllSheltersAsync();
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                return View(model);
            }

            try
            {
                await this.service.AddPetForAdoptionAsync(model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new pet for adoptionn! Please try again later or contact administrator.");
                model.Shelters = await this.shelterService.AllSheltersAsync();
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                return this.View(model);
            }

            return RedirectToAction("All", "Pet");
        }
    }
}
