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
    public class VoteAPIController : ControllerBase
    {
        private readonly MvcVoteCandidatContext _context;

        public VoteAPIController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: api/VoteAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vote>>> GetVote()
        {
            var votes = await _context.Vote
                .Include(v => v.Candidat)
                .ToListAsync();

        return votes;
        }

        // GET: api/VoteAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetVote(int id)
        {
            var vote = await _context.Vote
            .Include(v => v.Candidat) // Charge les données de l'équipe pour le vote spécifique
            .FirstOrDefaultAsync(v => v.voteId == id);

            if (vote == null)
            {
                return NotFound();
            }

            return vote;
        }

        // PUT: api/VoteAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVote(int id, Vote vote)
        {
            if (id != vote.voteId)
            {
                return BadRequest();
            }

            _context.Entry(vote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
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

        // POST: api/VoteAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vote>> PostVote(Vote vote)
        {
            _context.Vote.Add(vote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVote), new { id = vote.voteId }, vote);
        }

        // DELETE: api/VoteAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote(int id)
        {
            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            _context.Vote.Remove(vote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.voteId == id);
        }
    }
}
