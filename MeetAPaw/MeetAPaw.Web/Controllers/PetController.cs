using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Pet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MeetAPaw.Common.NotificationMessagesConstants;

namespace MeetAPaw.Web.Controllers
{
    [Authorize]
    public class PetController : BaseController
    {
        private readonly IPetService service;
        private readonly IPetTypeService petTypeService;
        private readonly IOwnerService ownerService;

        public PetController(
            IPetService service,
            IPetTypeService petTypeService,
            IOwnerService ownerService)
        {
            this.service = service;
            this.petTypeService = petTypeService;
            this.ownerService = ownerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await this.service.GetAllPetsAsync();
            return View(model);
        }

        public async Task<IActionResult> Profile(int id)
        {
            var model = await service.GetProfileAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

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
            bool isOwner = await this.ownerService.OwnerExistsByUserIdAsync(this.User.GetId()!);
           
            if (!isOwner)
            {
                this.TempData[ErrorMessage] = "You must become an owner in order to add new pets!";

                return this.RedirectToAction("Adopt", "Owner"); //!!!!
           
            }

            AddPetViewModel viewModel = new AddPetViewModel()
            {
                PetsTypes = await this.petTypeService.AllPetTypesAsync()
            };

           // var model = await service.GetNewAddPetAsync();

            viewModel.OwnerId = GetUserId();

            return View(viewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPetViewModel model)
        {
            bool isOwner = await this.ownerService.OwnerExistsByUserIdAsync(this.User.GetId()!);

            if (!isOwner)
            {
                this.TempData[ErrorMessage] = "You must become an owner in order to add new pets!";

                return this.RedirectToAction("Adopt", "Owner"); //!!!!

            }

            bool petTypeExists = await this.petTypeService.ExistsByIdAsync(model.PetTypeId);

            if (!petTypeExists)
            {
                ModelState.AddModelError(nameof(model.PetTypeId), "Selected pet type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                return View(model);
            }

            try
            {
                string? ownerId = await this.ownerService.GetOwnerIdByUserIdAsync(this.User.GetId()!);

                await this.service.AddPetAsync(model, ownerId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new pet! Please try again later or contact administrator.");
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                return this.View(model);
            }

            return RedirectToAction("All", "Pet");
        }
    }
}
