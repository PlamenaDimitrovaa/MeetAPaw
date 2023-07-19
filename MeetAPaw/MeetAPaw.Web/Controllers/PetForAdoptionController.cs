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

        public PetForAdoptionController(
            IPetForAdoptionService service,
            IPetTypeService petService)
        {
            this.service = service;
            this.petTypeService = petService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddPetForAdoptionViewModel viewModel = new AddPetForAdoptionViewModel()
            {
                PetsTypes = await this.petTypeService.AllPetTypesAsync()
            };


            viewModel.UserId = GetUserId();

            return View(viewModel);
        }
    }
}
