﻿using MeetAPaw.Services.Data.Interfaces;
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

        public PetController(
            IPetService service,
            IPetTypeService petTypeService)
        {
            this.service = service;
            this.petTypeService = petTypeService;
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
                await this.service.AddPetAsync(model, this.User.GetId()!);
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
