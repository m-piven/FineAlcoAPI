using AutoMapper;
using FineAlcoAPI.Entities;
using FineAlcoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using FineAlcoAPI.Services;

namespace FineAlcoAPI.Controllers
{
    [Route("api/bar")]
    public class BarController : ControllerBase
    {
        private readonly IBarService _barService;

        public BarController(IBarService barservice)
        {
            _barService = barservice;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBar([FromBody] BarUpdateDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _barService.UpdateBar(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteBar([FromRoute] int id)
        {
            _barService.DeleteBar(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateBar([FromBody] CreateBarDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _barService.CreateBar(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BarDto>> GetAll()
        {
            var barDtos = _barService.GetAll();

            return Ok(barDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<BarDto>> Get([FromRoute] int id)
        {
            var barDto = _barService.GetById(id);
            return Ok(barDto);
        }

        [HttpGet("search")]

        public ActionResult<IEnumerable<BarDto>> GetByName([FromQuery] string name)
        {
            var barDto = _barService.GetByName(name);
            return Ok(barDto);
        }
    }
}
