using DetroitLionsTrackerApi.BusinessLayer.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonBusinessLayer _seasonBusinessLayer;

        public SeasonController(ISeasonBusinessLayer seasonBusinessLayer)
        {
            _seasonBusinessLayer = seasonBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Season), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostSeason([FromBody] SeasonRequest seasonRequest)
        {
            var result = await _seasonBusinessLayer.CreateSeason(seasonRequest);

            return Ok(result);
        }

        [HttpPut("{seasonId}")]
        [ProducesResponseType(typeof(Season), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSeason([FromRoute] long seasonId, [FromBody] SeasonRequest seasonRequest)
        {
            if (seasonId != seasonRequest.SeasonId)
            {
                return BadRequest($"Season ID provided in route ({seasonId}) must match Season ID provided in body ({seasonRequest.SeasonId})");
            }

            try
            {
                var season = await _seasonBusinessLayer.UpdateSeason(seasonId, seasonRequest);
                return Ok(season);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/Seasons")]
        [ProducesResponseType(typeof(IEnumerable<Season>), StatusCodes.Status200OK)]
        public IActionResult GetSeasonsByFilter([FromQuery] SeasonFilterParameters filters)
        {
            var seasons = _seasonBusinessLayer.GetSeasonsByFilter(filters);
            return Ok(seasons);
        }

        [HttpDelete("{seasonId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSeason(long seasonId)
        {
            try
            {
                await _seasonBusinessLayer.DeleteSeason(seasonId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
