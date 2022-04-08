using FineAlcoAPI.Entities;
using FineAlcoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FineAlcoAPI.Controllers
{
    [Route("api/bar/{barId}/alcoDrink")]
    [ApiController]
    public class AlcoDrinkController : ControllerBase
    {
        private readonly IAlcoDrinkService _alcoDrinkService;

        public AlcoDrinkController(IAlcoDrinkService alcoDrinkService)
        {
            _alcoDrinkService = alcoDrinkService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int barId, [FromBody] AlcoDrinkDto dto)
        {
            var newAlcoDrinkId = _alcoDrinkService.Create(barId, dto);

            return Created($"api/bar/{barId}/AlcoDrink/{newAlcoDrinkId}", null);
        }
    }
}
