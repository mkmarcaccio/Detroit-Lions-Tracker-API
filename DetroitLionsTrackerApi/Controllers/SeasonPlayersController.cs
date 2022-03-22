using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DetroitLionsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonPlayersController : ControllerBase
    {
        private readonly ISeasonPlayersBusinessLayer _seasonPlayersBusinessLayer;

        public SeasonPlayersController(ISeasonPlayersBusinessLayer seasonPlayersBusinessLayer)
        {
            _seasonPlayersBusinessLayer = seasonPlayersBusinessLayer;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SeasonPlayers), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostSeasonPlayers([FromBody] SeasonPlayersRequest seasonPlayersRequest)
        {
            var result = await _seasonPlayersBusinessLayer.CreateSeasonPlayers(seasonPlayersRequest);

            return Ok(result);
        }

        [HttpPut("{seasonPlayersId}")]
        [ProducesResponseType(typeof(SeasonPlayers), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSeasonPlayers([FromRoute] long seasonPlayersId, [FromBody] SeasonPlayersRequest seasonPlayersRequest)
        {
            if (seasonPlayersId != seasonPlayersRequest.SeasonPlayersId)
            {
                return BadRequest($"SeasonPlayers ID provided in route ({seasonPlayersId}) must match SeasonPlayers ID provided in body ({seasonPlayersRequest.SeasonPlayersId})");
            }

            try
            {
                var seasonPlayers = await _seasonPlayersBusinessLayer.UpdateSeasonPlayers(seasonPlayersId, seasonPlayersRequest);
                return Ok(seasonPlayers);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/SeasonPlayers")]
        [ProducesResponseType(typeof(IEnumerable<SeasonPlayers>), StatusCodes.Status200OK)]
        public IActionResult GetSeasonPlayersByFilter([FromQuery] SeasonPlayersFilterParameters filters)
        {
            var seasonPlayers = _seasonPlayersBusinessLayer.GetSeasonPlayersByFilter(filters);
            return Ok(seasonPlayers);
        }

        [HttpDelete("{seasonPlayersId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSeasonPlayers(long seasonPlayersId)
        {
            try
            {
                await _seasonPlayersBusinessLayer.DeleteSeasonPlayers(seasonPlayersId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
