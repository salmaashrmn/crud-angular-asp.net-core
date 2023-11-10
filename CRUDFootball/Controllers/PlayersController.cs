using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDFootball.Data;
using Microsoft.AspNetCore.Mvc;
using CRUDFootball.Services;
using CRUDFootball.Models;

namespace CRUDFootball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _playerService;

        public PlayersController(IPlayersService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<IEnumerable<Players>> Get()
        {
            return await _playerService.GetPlayersList();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Players>> Get(int id)
        {
            var player = await _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // POST: api/Players
        [HttpPost]
        public async Task<ActionResult<Players>> Post(Players player)
        {
            await _playerService.CreatePlayer(player);

            return CreatedAtAction("Post", new { id = player.Id }, player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Players player)
        {
            if (id != player.Id)
            {
                return BadRequest("Not a valid player id");
            }

            await _playerService.UpdatePlayer(player);

            return NoContent();
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid player id");

            var player = await _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }

            await _playerService.DeletePlayer(player);

            return NoContent();
        }
    }
}
