using DetroitLionsTrackerApi.BusinessLayer.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameBusinessLayer _gameBusinessLayer;

        public GameController(IGameBusinessLayer gameBusinessLayer)
        {
            _gameBusinessLayer = gameBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostGame([FromBody] GameRequest gameRequest)
        {
            var result = await _gameBusinessLayer.CreateGame(gameRequest);

            return Ok(result);
        }

        [HttpPut("{gameId}")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGame([FromRoute] long gameId, [FromBody] GameRequest gameRequest)
        {
            if (gameId != gameRequest.GameId)
            {
                return BadRequest($"Game ID provided in route ({gameId}) must match Game ID provided in body ({gameRequest.GameId})");
            }

            try
            {
                var game = await _gameBusinessLayer.UpdateGame(gameId, gameRequest);
                return Ok(game);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/Games")]
        [ProducesResponseType(typeof(IEnumerable<Game>), StatusCodes.Status200OK)]
        public IActionResult GetGamesByFilter([FromQuery] GameFilterParameters filters)
        {
            var games = _gameBusinessLayer.GetGamesByFilter(filters);
            return Ok(games);
        }

        [HttpDelete("{gameId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteGame(long gameId)
        {
            try
            {
                await _gameBusinessLayer.DeleteGame(gameId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
