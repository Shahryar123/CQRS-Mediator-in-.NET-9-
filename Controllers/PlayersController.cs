using Microsoft.AspNetCore.Mvc;
using CQRS_and_Mediator.Entities;
using CQRS_and_Mediator.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_Mediator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        VideoGameAppDBContext _context;

        public PlayersController(VideoGameAppDBContext context)
        {
            _context = context;
        }   
        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetAll()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Create(Player player)
        {
            if (player == null)
            {
                return BadRequest("Player cannot be null");
            }
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = player.Id }, player);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetById(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found");
            }
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest("Player ID mismatch");
            }
            var existingPlayer = await _context.Players.FindAsync(id);
            if (existingPlayer == null)
            {
                return NotFound($"Player with ID {id} not found");
            }
            existingPlayer.Name = player.Name;
            existingPlayer.Level = player.Level;
            _context.Entry(existingPlayer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found");
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
