using MeetAPaw.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetAPaw.Web.Controllers
{
    public class ShelterController : BaseController
    {
        private readonly IShelterService shelterService;
        private readonly ILogger logger;
        public ShelterController(IShelterService _shelterService,
            ILogger<ShelterController> _logger)
        {
            shelterService = _shelterService;       
            logger = _logger;
        }
        public async Task<IActionResult> All()
        {
            var shelters = await this.shelterService.AllSheltersAsync();
            
            return View(shelters);
        }

        public async Task<IActionResult> Profile(int id)
        {
            var model = await shelterService.GetProfileAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            logger.LogInformation("Successfully visualized profile of a shelter.");
            return View(model);
        }
    }
}
