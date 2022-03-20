using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerBusinessLayer _playerBusinessLayer;

        public PlayerController(IPlayerBusinessLayer playerBusinessLayer)
        {
            _playerBusinessLayer = playerBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostPlayer([FromBody] PlayerRequest playerRequest)
        {
            var result = await _playerBusinessLayer.CreatePlayer(playerRequest);

            return Ok(result);
        }

        [HttpPut("{playerId}")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePlayer([FromRoute] long playerId, [FromBody] PlayerRequest playerRequest)
        {
            if (playerId != playerRequest.PlayerId)
            {
                return BadRequest($"Player ID provided in route ({playerId}) must match Player ID provided in body ({playerRequest.PlayerId})");
            }

            try
            {
                var player = await _playerBusinessLayer.UpdatePlayer(playerId, playerRequest);
                return Ok(player);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/Players")]
        [ProducesResponseType(typeof(IEnumerable<Player>), StatusCodes.Status200OK)]
        public IActionResult GetPlayersByFilter([FromQuery] PlayerFilterParameters filters)
        {
            var players = _playerBusinessLayer.GetPlayersByFilter(filters);
            return Ok(players);
        }

        [HttpDelete("{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePlayer(long playerId)
        {
            try
            {
                await _playerBusinessLayer.DeletePlayer(playerId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
