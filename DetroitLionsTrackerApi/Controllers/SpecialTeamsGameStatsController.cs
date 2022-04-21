using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialTeamsGameStatsController : ControllerBase
    {
        private readonly ISpecialTeamsGameStatsBusinessLayer _specialTeamsGameStatsBusinessLayer;

        public SpecialTeamsGameStatsController(ISpecialTeamsGameStatsBusinessLayer specialTeamsGameStatsBusinessLayer)
        {
            _specialTeamsGameStatsBusinessLayer = specialTeamsGameStatsBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SpecialTeamsGameStats), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostSpecialTeamsGameStats([FromBody] SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest)
        {
            var result = await _specialTeamsGameStatsBusinessLayer.CreateSpecialTeamsGameStats(specialTeamsGameStatsRequest);

            return Ok(result);
        }

        [HttpPut("{gameId}/{playerId}")]
        [ProducesResponseType(typeof(SpecialTeamsGameStats), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSpecialTeamsGameStats([FromRoute] long gameId, [FromRoute] long playerId, [FromBody] SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest)
        {
            if (gameId != specialTeamsGameStatsRequest.GameId)
            {
                return BadRequest($"Game ID provided in route ({gameId}) must match Game ID provided in body ({specialTeamsGameStatsRequest.GameId})");
            }

            if (playerId != specialTeamsGameStatsRequest.PlayerId)
            {
                return BadRequest($"Player ID provided in route ({playerId}) must match Player ID provided in body ({specialTeamsGameStatsRequest.PlayerId})");
            }

            try
            {
                var specialTeamsGameStats = await _specialTeamsGameStatsBusinessLayer.UpdateSpecialTeamsGameStats(gameId, playerId, specialTeamsGameStatsRequest);
                return Ok(specialTeamsGameStats);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/SpecialTeamsGameStats")]
        [ProducesResponseType(typeof(IEnumerable<SpecialTeamsGameStats>), StatusCodes.Status200OK)]
        public IActionResult GetSpecialTeamsGameStatsByFilter([FromQuery] SpecialTeamsGameStatsFilterParameters filters)
        {
            var specialTeamsGameStats = _specialTeamsGameStatsBusinessLayer.GetSpecialTeamsGameStatsByFilter(filters);
            return Ok(specialTeamsGameStats);
        }

        [HttpDelete("{gameId}/{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSpecialTeamsGameStats(long gameId, long playerId)
        {
            try
            {
                await _specialTeamsGameStatsBusinessLayer.DeleteSpecialTeamsGameStats(gameId, playerId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
