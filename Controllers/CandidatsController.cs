using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Data;
using VoteFCSoccer.Models;

namespace VoteFCSoccer.Controllers
{
    public class CandidatsController : Controller
    {
        private readonly MvcVoteCandidatContext _context;

        public CandidatsController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: Candidats
        public async Task<IActionResult> Index()
        {
            var query = from candidat in _context.Set<Candidat>() 
                         join libelleVote in _context.Set<LibelleVote>()
                         on candidat.LibelleId equals libelleVote.LibelleId
                         select new LibelleVoteCandidatViewModel 
                         {Candidat = candidat, LibelleVote = libelleVote};

            return View(await query.ToListAsync());
        }

        // GET: Candidats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidat
                .Include(e => e.LibelleVote)
                .FirstOrDefaultAsync(m => m.CandidatId == id);
            if (candidat == null)
            {
                return NotFound();
            }
            
            var votes = from v in _context.Vote
                        select v;
            
            votes = votes.Where(s => s.CandidatId == candidat.CandidatId);

            candidat.Votes = await votes.ToListAsync();

            if(candidat.Votes == null)
                candidat.Votes = default!;

            return View(candidat);
        }

        // GET: Candidats/Create
        public IActionResult Create()
        {
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle");
            return View();
        }

        // POST: Candidats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidatId,Nom,Logo,LibelleId")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle", candidat.LibelleId);
            return View(candidat);
        }

        // GET: Candidats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidat.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle", candidat.LibelleId);
            return View(candidat);
        }

        // POST: Candidats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidatId,Nom,Logo,LibelleId")] Candidat candidat)
        {
            if (id != candidat.CandidatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatExists(candidat.CandidatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle", candidat.LibelleId);
            return View(candidat);
        }

        // GET: Candidats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidat
                .Include(e => e.LibelleVote)
                .FirstOrDefaultAsync(m => m.CandidatId == id);
            if (candidat == null)
            {
                return NotFound();
            }

            return View(candidat);
        }

        // POST: Candidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidat = await _context.Candidat.FindAsync(id);
            if (candidat != null)
            {
                _context.Candidat.Remove(candidat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatExists(int id)
        {
            return _context.Candidat.Any(c => c.CandidatId == id);
        }
    }
}
