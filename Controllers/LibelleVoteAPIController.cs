using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Data;
using VoteFCSoccer.Models;

namespace VoteFCSoccer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibelleVoteAPIController : ControllerBase
    {
        private readonly MvcVoteCandidatContext _context;

        public LibelleVoteAPIController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: api/LibelleVoteAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibelleVote>>> GetLibelleVote()
        {
            return await _context.LibelleVote.ToListAsync();
        }

        // GET: api/LibelleVoteAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibelleVote>> GetLibelleVote(int id)
        {
            var libelleVote = await _context.LibelleVote.FindAsync(id);

            if (libelleVote == null)
            {
                return NotFound();
            }

            return libelleVote;
        }

        // PUT: api/LibelleVoteAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibelleVote(int id, LibelleVote libelleVote)
        {
            if (id != libelleVote.LibelleId)
            {
                return BadRequest();
            }

            _context.Entry(libelleVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibelleVoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LibelleVoteAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibelleVote>> PostLibelleVote(LibelleVote libelleVote)
        {
            _context.LibelleVote.Add(libelleVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibelleVote), new { id = libelleVote.LibelleId }, libelleVote);
        }

        // DELETE: api/LibelleVoteAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibelleVote(int id)
        {
            var libelleVote = await _context.LibelleVote.FindAsync(id);
            if (libelleVote == null)
            {
                return NotFound();
            }

            _context.LibelleVote.Remove(libelleVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibelleVoteExists(int id)
        {
            return _context.LibelleVote.Any(e => e.LibelleId == id);
        }
    }
}
