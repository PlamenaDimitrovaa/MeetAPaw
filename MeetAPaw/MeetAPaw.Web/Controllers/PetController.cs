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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                EditPetViewModel viewModel = await this.service.GetPetForEditByIdAsync(id);

                viewModel.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                viewModel.OwnerId = GetUserId();

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
            if (!this.ModelState.IsValid)
            {
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                return this.View(model);
            }

            bool petExists = await this.service
                .PetExistsByIdAsync(id);

            if (!petExists)
            {
                return this.RedirectToAction("All", "Pet");
            }

            try
            {
                await this.service.EditPetByIdAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the pet. Please try again later or contact administrator!");
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();

                return this.View(model);
            }

            return this.RedirectToAction("Profile", "Pet", new { id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool houseExists = await this.service
                .PetExistsByIdAsync(id);

            if (!houseExists)
            {
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
                return this.RedirectToAction("All", "Pet");
            }

            try
            {
                await this.service.DeletePetByIdAsync(id);

                return this.RedirectToAction("All", "Pet");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
