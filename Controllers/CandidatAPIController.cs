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
    public class CandidatAPIController : ControllerBase
    {
        private readonly MvcVoteCandidatContext _context;

        public CandidatAPIController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: api/CandidatAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetCandidat()
        {
            return await _context.Candidat.ToListAsync();
        }

        // GET: api/CandidatAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidat>> GetCandidat(int id)
        {
            var candidat = await _context.Candidat.FindAsync(id);

            if (candidat == null)
            {
                return NotFound();
            }

            return candidat;
        }

        // PUT: api/CandidatAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidat(int id, Candidat candidat)
        {
            if (id != candidat.CandidatId)
            {
                return BadRequest();
            }

            _context.Entry(candidat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatExists(id))
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

        // POST: api/CandidatAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candidat>> PostCandidat(Candidat candidat)
        {
            _context.Candidat.Add(candidat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCandidat), new { id = candidat.CandidatId }, candidat);
        }

        // DELETE: api/CandidatAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidat(int id)
        {
            var candidat = await _context.Candidat.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }

            _context.Candidat.Remove(candidat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatExists(int id)
        {
            return _context.Candidat.Any(e => e.CandidatId == id);
        }
    }
}
