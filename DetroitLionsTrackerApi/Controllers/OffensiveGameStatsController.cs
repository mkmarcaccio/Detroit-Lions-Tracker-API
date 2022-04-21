using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffensiveGameStatsController : ControllerBase
    {
        private readonly IOffensiveGameStatsBusinessLayer _offensiveGameStatsBusinessLayer;

        public OffensiveGameStatsController(IOffensiveGameStatsBusinessLayer offensiveGameStatsBusinessLayer)
        {
            _offensiveGameStatsBusinessLayer = offensiveGameStatsBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OffensiveGameStats), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostOffensiveGameStats([FromBody] OffensiveGameStatsRequest offensiveGameStatsRequest)
        {
            var result = await _offensiveGameStatsBusinessLayer.CreateOffensiveGameStats(offensiveGameStatsRequest);

            return Ok(result);
        }

        [HttpPut("{gameId}/{playerId}")]
        [ProducesResponseType(typeof(OffensiveGameStats), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOffensiveGameStats([FromRoute] long gameId, [FromRoute] long playerId, [FromBody] OffensiveGameStatsRequest offensiveGameStatsRequest)
        {
            if (gameId != offensiveGameStatsRequest.GameId)
            {
                return BadRequest($"Game ID provided in route ({gameId}) must match Game ID provided in body ({offensiveGameStatsRequest.GameId})");
            }

            if (playerId != offensiveGameStatsRequest.PlayerId)
            {
                return BadRequest($"Player ID provided in route ({playerId}) must match Player ID provided in body ({offensiveGameStatsRequest.PlayerId})");
            }

            try
            {
                var offensiveGameStats = await _offensiveGameStatsBusinessLayer.UpdateOffensiveGameStats(gameId, playerId, offensiveGameStatsRequest);
                return Ok(offensiveGameStats);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/OffensiveGameStats")]
        [ProducesResponseType(typeof(IEnumerable<OffensiveGameStats>), StatusCodes.Status200OK)]
        public IActionResult GetOffensiveGameStatsByFilter([FromQuery] OffensiveGameStatsFilterParameters filters)
        {
            var offensiveGameStats = _offensiveGameStatsBusinessLayer.GetOffensiveGameStatsByFilter(filters);
            return Ok(offensiveGameStats);
        }

        [HttpDelete("{gameId}/{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOffensiveGameStats(long gameId, long playerId)
        {
            try
            {
                await _offensiveGameStatsBusinessLayer.DeleteOffensiveGameStats(gameId, playerId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
