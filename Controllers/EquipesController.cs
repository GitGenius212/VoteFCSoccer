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
    public class EquipesController : Controller
    {
        private readonly MvcVoteEquipeContext _context;

        public EquipesController(MvcVoteEquipeContext context)
        {
            _context = context;
        }

        // GET: Equipes
        public async Task<IActionResult> Index()
        {
            var query = from equipe in _context.Set<Equipe>() 
                         join libelleVote in _context.Set<LibelleVote>()
                         on equipe.LibelleId equals libelleVote.LibelleId
                         select new LibelleVoteEquipeViewModel 
                         {Equipe = equipe, LibelleVote = libelleVote};

            return View(await query.ToListAsync());
        }

        // GET: Equipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .Include(e => e.LibelleVote)
                .FirstOrDefaultAsync(m => m.EquipeId == id);
            if (equipe == null)
            {
                return NotFound();
            }
            
            var votes = from v in _context.Vote
                        select v;
            
            votes = votes.Where(s => s.EquipeId == equipe.EquipeId);

            equipe.Votes = await votes.ToListAsync();

            if(equipe.Votes == null)
                equipe.Votes = default!;

            return View(equipe);
        }

        // GET: Equipes/Create
        public IActionResult Create()
        {
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle");
            return View();
        }

        // POST: Equipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipeId,Nom,Logo,Pseudo,League,LeaguePseudo,LibelleId")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle", equipe.LibelleId);
            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "LibelleId", equipe.LibelleId);
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipeId,Nom,Logo,Pseudo,League,LeaguePseudo,LibelleId")] Equipe equipe)
        {
            if (id != equipe.EquipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeExists(equipe.EquipeId))
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
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "LibelleId", equipe.LibelleId);
            return View(equipe);
        }

        // GET: Equipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .Include(e => e.LibelleVote)
                .FirstOrDefaultAsync(m => m.EquipeId == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipe.Remove(equipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeExists(int id)
        {
            return _context.Equipe.Any(e => e.EquipeId == id);
        }
    }
}
