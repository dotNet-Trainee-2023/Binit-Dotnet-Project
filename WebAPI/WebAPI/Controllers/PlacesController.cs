using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Data;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApiDBContext _dbcontext;

        private readonly IPlaceService _placeService;
        public PlacesController(ApiDBContext dbcontext, IPlaceService placeService)
        {
            _dbcontext = dbcontext;
            _placeService = placeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            var places = await _placeService.GetAllPlaces();
            if(places == null)
            {
                return NotFound();
            }
            return Ok(places);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlace([FromBody] Place place)
        {
            await _placeService.Create(place);
            return Ok(place);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceById([FromRoute] Guid id)
        {
            var place = await _placeService.GetById(id);
            if(place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace([FromRoute] Guid id)
        {
            var place = await _placeService.GetById(id);

            if (place == null)
                return NotFound();

            var retVal = await _placeService.Delete(place);

            return Ok(retVal);

        }
    }
}
