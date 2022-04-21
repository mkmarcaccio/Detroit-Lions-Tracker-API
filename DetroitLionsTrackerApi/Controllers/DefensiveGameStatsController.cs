using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefensiveGameStatsController : ControllerBase
    {
        private readonly IDefensiveGameStatsBusinessLayer _defensiveGameStatsBusinessLayer;

        public DefensiveGameStatsController(IDefensiveGameStatsBusinessLayer defensiveGameStatsBusinessLayer)
        {
            _defensiveGameStatsBusinessLayer = defensiveGameStatsBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DefensiveGameStats), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostDefensiveGameStats([FromBody] DefensiveGameStatsRequest defensiveGameStatsRequest)
        {
            var result = await _defensiveGameStatsBusinessLayer.CreateDefensiveGameStats(defensiveGameStatsRequest);

            return Ok(result);
        }

        [HttpPut("{gameId}/{playerId}")]
        [ProducesResponseType(typeof(DefensiveGameStats), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDefensiveGameStats([FromRoute] long gameId, [FromRoute] long playerId, [FromBody] DefensiveGameStatsRequest defensiveGameStatsRequest)
        {
            if (gameId != defensiveGameStatsRequest.GameId)
            {
                return BadRequest($"Game ID provided in route ({gameId}) must match Game ID provided in body ({defensiveGameStatsRequest.GameId})");
            }

            if (playerId != defensiveGameStatsRequest.PlayerId)
            {
                return BadRequest($"Player ID provided in route ({playerId}) must match Player ID provided in body ({defensiveGameStatsRequest.PlayerId})");
            }

            try
            {
                var defensiveGameStats = await _defensiveGameStatsBusinessLayer.UpdateDefensiveGameStats(gameId, playerId, defensiveGameStatsRequest);
                return Ok(defensiveGameStats);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/DefensiveGameStats")]
        [ProducesResponseType(typeof(IEnumerable<DefensiveGameStats>), StatusCodes.Status200OK)]
        public IActionResult GetDefensiveGameStatsByFilter([FromQuery] DefensiveGameStatsFilterParameters filters)
        {
            var defensiveGameStats = _defensiveGameStatsBusinessLayer.GetDefensiveGameStatsByFilter(filters);
            return Ok(defensiveGameStats);
        }

        [HttpDelete("{gameId}/{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteDefensiveGameStats(long gameId, long playerId)
        {
            try
            {
                await _defensiveGameStatsBusinessLayer.DeleteDefensiveGameStats(gameId, playerId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
