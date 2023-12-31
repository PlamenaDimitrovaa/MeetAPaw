﻿using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.PetForAdoption;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MeetAPaw.Common.NotificationMessagesConstants;

namespace MeetAPaw.Web.Controllers
{
    public class PetForAdoptionController : BaseController
    {
        private readonly IPetForAdoptionService service;
        private readonly IPetTypeService petTypeService;
        private readonly IShelterService shelterService;
        private readonly ILogger logger;
        public PetForAdoptionController(
            IPetForAdoptionService service,
            IPetTypeService petService,
            IShelterService shelterService,
            ILogger<PetForAdoptionController> logger)
        {
            this.service = service;
            this.petTypeService = petService;
            this.shelterService = shelterService;
            this.logger = logger;
        }

        public async Task<IActionResult> Profile(int id)
        {
            var model = await this.service.GetProfileToPetForAdoptionAsync(id);

            logger.LogInformation("Successfully visualized profile of the pet for adoption.");

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddPetForAdoptionViewModel viewModel = new AddPetForAdoptionViewModel()
            {
                Shelters = await this.shelterService.AllSheltersAsync(),
                PetsTypes = await this.petTypeService.AllPetTypesAsync()
            };

            logger.LogInformation("Successfully visualized add pet for adoption form");
            viewModel.UserId = GetUserId();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPetForAdoptionViewModel model)
        {
            bool petTypeExists = await this.petTypeService.ExistsByIdAsync(model.PetTypeId);

            if (!petTypeExists)
            {
                logger.LogWarning("This pet type does not exists");
                ModelState.AddModelError(nameof(model.PetTypeId), "Selected pet type does not exist!");
            }

            bool sheltersExists = await this.shelterService.ShelterExistsByIdAsync(model.ShelterId);

            if (!sheltersExists)
            {
                logger.LogWarning("This shelter does not exists");
                ModelState.AddModelError(nameof(model.ShelterId), "Selected shelter does not exist!");
            }

            if (this.User.GetId() != model.UserId && !User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be registered in order to add pets for adoption";
                return RedirectToAction("Adopt", "Adopt");
            }

            DateTime dateOfBirth = DateTime.Parse(model.DateOfBirth);

            if (dateOfBirth >= DateTime.UtcNow)
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), "Selected date of birth is not valid!");
            }

            if (!ModelState.IsValid)
            {
                model.Shelters = await this.shelterService.AllSheltersAsync();
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                TempData[ErrorMessage] = "You cannot add pet for adoption!";
                logger.LogWarning("You cannot add pet for adoption");
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
                TempData[ErrorMessage] = "You cannot add pet for adoption!";
                logger.LogWarning("You cannot add pet for adoption");
                return this.View(model);
            }

            logger.LogInformation("You have successfully added a pet for adoption");
            TempData[SuccessMessage] = "You have successfully added a pet for adoption!";
            return RedirectToAction("Adopt", "Adopt");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                EditPetForAdoptionViewModel viewModel = await this.service.GetPetForAdoptionForEditByIdAsync(id);

                viewModel.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                viewModel.Shelters = await this.shelterService.AllSheltersAsync();
                viewModel.UserId = GetUserId();

                logger.LogInformation("Successfully visualized edit pet for adoption form.");

                return View(viewModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPetForAdoptionViewModel model)
        {
            bool petExists = await this.service
                .PetForAdoptionExistsByIdAsync(id);

            if (!petExists)
            {
                logger.LogWarning("This pet does not exists.");
                TempData[ErrorMessage] = "You cannot edit this pet for adoption! It does not exists!";
                return this.RedirectToAction("Adopt", "Adopt");
            }

            bool sheltersExists = await this.shelterService.ShelterExistsByIdAsync(model.ShelterId);

            if (!sheltersExists)
            {
                logger.LogWarning("This shelter does not exists");
                ModelState.AddModelError(nameof(model.ShelterId), "Selected shelter does not exist!");
            }

            if (this.User.GetId() != model.UserId && !User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an owner in order to edit the pet";
                return this.RedirectToAction("Adopt", "Adopt");
            }

            string date = WebUtility.HtmlEncode(model.DateOfBirth.ToString());
            DateTime dateOfBirth = DateTime.Parse(date);

            if (dateOfBirth >= DateTime.UtcNow)
            {
                logger.LogWarning("This date of birth is not valid");
                ModelState.AddModelError(nameof(model.DateOfBirth), "Selected date of birth is not valid!");
            }

            if (!this.ModelState.IsValid)
            {
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                model.Shelters = await this.shelterService.AllSheltersAsync();
                TempData[ErrorMessage] = "You cannot edit pet for adoption!";
                logger.LogWarning("You cannot edit pet for adoption");
                return this.View(model);
            }

            try
            {
                await this.service.EditPetForAdoptionByIdAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the pet. Please try again later or contact administrator!");
                model.PetsTypes = await this.petTypeService.AllPetTypesAsync();
                TempData[ErrorMessage] = "You cannot edit pet for adoption!";
                logger.LogWarning("You cannot edit pet for adoption");
                return this.View(model);
            }

            logger.LogInformation("Successfully edited pet for adoption");
            TempData[SuccessMessage] = "You have successfully edited the pet for adoption!";
            return this.RedirectToAction("Profile", "PetForAdoption", new { id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool petExists = await this.service
                .PetForAdoptionExistsByIdAsync(id);

            if (!petExists)
            {
                logger.LogWarning("This pet does not exists.");
                return this.RedirectToAction("Adopt", "Adopt");
            }

            try
            {
                PetForAdoptionPreDeleteDetailsViewModel viewModel =
                    await this.service.GetPetForAdoptionForDeleteByIdAsync(id);
                logger.LogInformation("Successfully visualized delete page");
                return this.View(viewModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PetForAdoptionPreDeleteDetailsViewModel model)
        {
            bool petExists = await this.service
                .PetForAdoptionExistsByIdAsync(id);

            if (!petExists)
            {
                logger.LogWarning("This pet does not exists");
                return this.RedirectToAction("Adopt", "Adopt");
            }

            try
            {
                await this.service.DeletePetForAdoptionByIdAsync(id);
                TempData[SuccessMessage] = "You have successfully deleted the pet for adoption!";
                logger.LogInformation("Successfully deleted pet for adoption");
                return this.RedirectToAction("Adopt", "Adopt");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
