﻿using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data.Interfaces;
using MeetAPaw.Web.Infrastructure.Extensions;
using MeetAPaw.Web.ViewModels.Adopt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var model = await this.service.GetPetsForAdoptionAsync();
            return View(model);
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
                return NotFound();
            }

            var adopter = this.User.GetId();

            if (adopter == null)
            {
                return Unauthorized(); 
            }

           
            await this.service.UpdatePetForAdoptionAsync(petForAdoption, adopter);

            await this.service.AddAdoption(adopter, petForAdoption);

            return RedirectToAction("Index", "Home"); 
        }
    }
}
