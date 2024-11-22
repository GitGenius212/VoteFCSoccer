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
    public class LibelleVotesController : Controller
    {
        private readonly MvcVoteCandidatContext _context;

        public LibelleVotesController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: LibelleVotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibelleVote.ToListAsync());
        }

        // GET: LibelleVotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libelleVote = await _context.LibelleVote
                .FirstOrDefaultAsync(m => m.LibelleId == id);
            if (libelleVote == null)
            {
                return NotFound();
            }

            var equipes = from e in _context.Candidat
                          select e;

            equipes = equipes.Where(s => s.LibelleId == libelleVote.LibelleId);
            libelleVote.Candidats = await equipes.ToListAsync();

            if(libelleVote.Candidats == null)
                libelleVote.Candidats = default!;


            return View(libelleVote);
        }

        // GET: LibelleVotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibelleVotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibelleId,Libelle")] LibelleVote libelleVote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libelleVote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libelleVote);
        }

        // GET: LibelleVotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libelleVote = await _context.LibelleVote.FindAsync(id);
            if (libelleVote == null)
            {
                return NotFound();
            }
            return View(libelleVote);
        }

        // POST: LibelleVotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibelleId,Libelle")] LibelleVote libelleVote)
        {
            if (id != libelleVote.LibelleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libelleVote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibelleVoteExists(libelleVote.LibelleId))
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
            return View(libelleVote);
        }

        // GET: LibelleVotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libelleVote = await _context.LibelleVote
                .FirstOrDefaultAsync(m => m.LibelleId == id);
            if (libelleVote == null)
            {
                return NotFound();
            }

            return View(libelleVote);
        }

        // POST: LibelleVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libelleVote = await _context.LibelleVote.FindAsync(id);
            if (libelleVote != null)
            {
                _context.LibelleVote.Remove(libelleVote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibelleVoteExists(int id)
        {
            return _context.LibelleVote.Any(e => e.LibelleId == id);
        }
    }
}
